# Unity Binary Utils
This package contains utilities to serialize and deserialize content in a particular byte array representation.

# Install

This package is not available in any UPM server. You must install it in your project like this:

1. In Unity, with your project open, open the Package Manager.
2. Either refer this Github project: https://github.com/AlephVault/unity-binary.git or clone it locally and refer it from disk.
3. Also, the following packages are dependencies you need to install accordingly (in the same way and also ensuring all the recursive dependencies are satisfied):

     - https://github.com/AlephVault/unity-support.git

# Usage

The main purpose of this package is to be able to convert primitive or arbitrary types to an array of bits. There are many purpose for this conversion to a byte array (one of them involves sending the data through streams, e.g. network streams) and, ideally, this conversion must be a bidirectional process.

_Disclaimer: The main parts of this implementation were taken from the original Unity's NetCode / MLAPI package, so most of the elements will look extremely familiar to developers used to it._

For this, everything starts with choosing whether it's needed to read or write at a given moment. and knowing the `AlephVault.Unity.Binary.ISerializable`-implementing type to use for this purpose. So let's say we have `MyType` defined like this:

```
using AlephVault.Unity.Binary;

class MyType : ISerializable {
    public void Serialize(Serializer serializer) {
        // We'll dive into this later.
    }
}
```

That object may have members and custom data that it's useful to dump as an array (to persist it or transmit it), so let's read data from this object:

```
using System.IO;
using AlephVault.Unity.Binary;

Stream someStream = ...get some writable stream...;

// Let's get or create a MyType object.
MyType myObj = new MyType(...);

// Let's make a Write-Serializer.
Serializer serializer = new Serializer(new Writer(stream));

// Serialize the object. It'll write into the stream.
myObj.Serialize(serializer);
```

And, if we want to write data into the object (this time from a readable stream):

```
using System.IO;
using AlephVault.Unity.Binary;

Stream someStream = ...get some readable stream...;

// Let's get or create a MyType object, perhaps empty this time.
MyType myObj = new MyType(...);

// Let's make a Read-Serializer.
Serializer serializer = new Serializer(new Reader(stream));

// Serialize the object. It'll read data from the stream and fill its fields.
myObj.Serialize(serializer);
```

It's important to understand that `myObj.Serialize(serializer)` is called in both the writing case or the reading case. The implementation will typically work for both cases simultaneously.

## A straightforward example

Let's say we have this particular structure:

```
using AlephVault.Unity.Binary;

public class MyStructure : ISerializable {
    public int A;
    public float B;
    public string C;

	public void Serialize(Serializer serializer) {
	    // Both for read and write purposes this will work.
	    serializer.Serialize(ref A); // First, reads or writes an int (32 bits).
	    serializer.Serialize(ref B); // Then, reads or writes a float.
	    serializer.Serialize(ref C); // Finally, reads or write a dynamic-length string.
	}
}
```

Under the hoods, when a `MyStructure` is written from an input stream, the process will involve these steps in order:

1. First, read 4 bytes and make an integer.
2. Then, read 4 bytes and make a float.
3. Then read a dynamic amount of bytes (following a specific implementation) and make a string.

then filling those values accordingly / given by explicit code calls.

But also when a `MyStructure` is dumped into an output stream the same order of operations will be preserved with the exact matching sizes:

1. First, write 4 bytes from an integer value.
2. Then, write 4 bytes from a float value.
3. Then, write a dynamic amount of bytes (following a specific implementation) from a string value.

This implementation is the easiest in this case, since primitive values (and others like Unity's `Vector3` or `Color32`) are supported out of the box.

## More complex examples

Let's see what happens with more complex cases:

### Complex / structured members

Let's say you have more than primitive objects. Instead, some members are custom classes or structs. How do you serialize them? By being explicit, member by member:

```
using AlephVault.Unity.Binary;

// Notice how this class is NOT ISerializable.
class Position
{
    public int X;
    public int Y;
}

// But this class IS serializable.
class BuildingPosition : ISerializable {
    public int Story;
    public Position Position;

    public void Serialize(Serializer serializer) {
        serializer.Serialize(ref Story);
        // The only thing to ensure, since in this case
        // the Position is a class, is that the field is
        // never null for this example:
        Position ??= new Position();
		serializer.Serialize(ref Position.X);
        serializer.Serialize(ref Position.Y);
    }
}
```

So the process is essentially the same, so far. The problem is, however, that this approach would be annoying if several `ISerializable` types had to serialize -in this case- the `Position` class like this case. Also, this approach only works if all the involved members are fields, and _not_ properties (with get/set accessors).

### Complex / structured ISerializable members

An alternative to the former case is to ensure the nested class is also Serializable and consistently implements this _simultaneous_ pattern as well. The implementation (now also making `Position` an `ISerializable` type) would be like this:

```
using AlephVault.Unity.Binary;

// Notice how this class is NOT ISerializable.
class Position : ISerializable
{
    public int X;
    public int Y;
    
	public void Serialize(Serializer serializer) {
	    serializer.Serialize(ref X);
	    serializer.Serialize(ref Y);
	}
}

// But this class IS serializable.
class BuildingPosition : ISerializable {
    public int Story;
    public Position Position;

    public void Serialize(Serializer serializer) {
        serializer.Serialize(ref Story);
        serializer.Serialize(ref Position);
    }
}
```

Now, `serializer.Serialize(ref Position)` works by delegating the serialization via calls to `.Serialize(serializer)` in nested classes makes things easier for all the implementors. Still, there's a gotcha here: again, this works with standard fields, _not_ properties (with get/set accessors).

### Dealing with custom logic

Let's say that our class is somewhat different this time: some of the members are properties (having both get/set accessors). How would we deal with them? Using `ref` will NOT work in this case.

Fortunately, we have the ability to write custom code, knowing whether the context involves reading from or writing into a serializer. **Still, we must now guarantee that we're doing the things properly in terms of consistency of reading/writing data**, both in order and size.

In this approach, we can still use the `ref` approach for non-property fields, but we can also use the new approach for these other cases. So let's assume that the `Story` is a get/set property instead of a field. We'd implement like this:

```
using AlephVault.Unity.Binary;

// Notice how this class is NOT ISerializable.
class Position : ISerializable
{
    public int X;
    public int Y;
    
	public void Serialize(Serializer serializer) {
	    serializer.Serialize(ref X);
	    serializer.Serialize(ref Y);
	}
}

// But this class IS serializable.
class BuildingPosition : ISerializable {
    public int Story {
        get => ...complex logic...,
        set => ...complex logic in terms of `value`...
    }
    public Position Position;

	// For good practice we create a new method to do
	// the serialization. This helps to retain order
	// of the read/write operations on both cases.
    private void SerializeStory(Serializer serializer) {
        int story_;
        // We detect whether it's reading or writing
        // and act accordingly. First, the writing
        // case of the data, and then the reading
        // case of the data.
		if (serializer.IsWriting) {
		    // Populate a variable from the property,
		    // when writing.
		    story_ = Story;
        }
        // Read or write the variable.
        serializer.Serialize(ref story_);
		if (serializer.IsReading) {
		    // Populate the property from the variable,
		    // when reading.
		    Story = story_;
        }
    }

    public void Serialize(Serializer serializer) {
	    SerializeStory(serializer);
        // The only thing to ensure, since in this case
        // the Position is a class, is that the field is
        // never null for this example:
        Position ??= new Position();
		Position.Serialize(serializer);
    }
}
```

Notice how there's some sort of unconditional code "in the middle" which is always executed. Then it is _sandwiched_ by the write-case first and the read-case later.

Another case could be if the property were, instead, a complex object. Be that object serializable or not, the code would be similar. Let's make another example where also the `Position` is a get/set property:

```
using AlephVault.Unity.Binary;

// Notice how this class is NOT ISerializable.
class Position : ISerializable
{
    public int X;
    public int Y;
    
	public void Serialize(Serializer serializer) {
	    serializer.Serialize(ref X);
	    serializer.Serialize(ref Y);
	}
}

// But this class IS serializable.
class BuildingPosition : ISerializable {
    public int Story {
        get => ...complex logic...,
        set => ...complex logic in terms of `value`...
    }
    public Position Position {
        get => ...complex logic...,
        set => ...complex logic in terms of `value`...
	}

	// For good practice we create a new method to do
	// the serialization. This helps to retain order
	// of the read/write operations on both cases.
    private void SerializeStory(Serializer serializer) {
        int story_;
        // We detect whether it's reading or writing
        // and act accordingly. First, the writing
        // case of the data, and then the reading
        // case of the data.
		if (serializer.IsWriting) {
		    // Populate a variable from the property,
		    // when writing.
		    story_ = Story;
        }
        // Read or write the variable.
        serializer.Serialize(ref story_);
		if (serializer.IsReading) {
		    // Populate the property from the variable,
		    // when reading.
		    Story = story_;
        }
    }

    // We also create a custom method for the position.
    private void SerializePosition(Serializer serializer) {
        Position position_;
		if (serializer.IsWriting) {
		    // Populate a variable from the property,
		    // when writing.
		    position_ = Position ?? new Position();
        }
        serializer.Serialize(ref position_);
		if (serializer.IsReading) {
		    // Populate the property from the position,
		    // when reading.
		    Position = position_;
        }
	}

    public void Serialize(Serializer serializer) {
	    SerializeStory(serializer);
	    SerializePosition(serializer);
    }
}
```

There are more complex cases that are possible here. For example, one could read / write objects which can be null. In this case, the writing case might involve:

1. If the object is null, write `false`.
2. If not null, instead, write `true` and then serialize the object.

while the reading case might involve:

1. Read a boolean.
2. If `false`, stop and set `null` to the member containing an object.
3. Otherwise, set a new object to the member and read/fill it from the serializer.

## Supported member types

When you want to read or write individual data elements, you call:

```
serializer.Serialize(ref someVariable);
```

But: what types are supported? These:

- `bool` and `bool?`.
- `char` and `char?`. In this case, a second argument `bool packed = true` is allowed. It tells whether the value will be compressed (with a special algorithm) or not.
- `byte`, `sbyte`, `byte?` and `sbyte?`.
- `short`, `ushort`, `short?` and `ushort?`. In these cases, a second argument `bool packed = true` is also allowed with the same meaning as in the `char` case.
- `int`, `uint`, `int?` and `uint?`. In these cases, a second argument `bool packed = true` is also allowed with the same meaning as in the `char` case.
- `long`, `ulong`, `long?` and `ulong?`. In these cases, a second argument `bool packed = true` is also allowed with the same meaning as in the `char` case.
- `float`, `double`, `float?` and `double?`. In these cases, a second argument `bool packed = true` is also allowed with the same meaning as in the `char` case.
- `string`. In these cases, a second argument `bool packed = true` is also allowed with the same meaning as in the `char` case.
- `Color`, `Color32`, `Color?` and `Color32?`.
- `Vector2`, `Vector3`, `Vector2?` and `Vector3?`. In these cases, a second argument `bool packed = true` is also allowed with the same meaning as in the `char` case.
- `Vector4`, `Quaternion`, `Vector4?` and `Quaternion?`. In these cases, a second argument `bool packed = true` is also allowed with the same meaning as in the `char` case.
- `Ray2D`, `Ray`, `Ray2D?` and `Ray?`. In these cases, a second argument `bool packed = true` is also allowed with the same meaning as in the `char` case.
- For every `T` among the previous non-nullable types, `T[]` is allowed. All the cases where `bool packed = true` is an argument for the override of that type is also allowed in this override for type `T[]` (e.g. arrays of types other than `bool`, `byte`, `sbyte`, `Color` and `Color32` accept this second argument).
- Any `T` or `T?` variable where `T` is an `enum` of any size. In these cases, a second argument `bool packed = true` is also allowed with the same meaning as in the `char` case.
     - There's no `T[]` override for enum types yet.
- Any `ISerializable`-implementing type. In this case, it's read/written first the _presence_ of the value (i.e. the value not being null/default) and then, if non-default, it's read/written by invoking the instance's `.Serialize(serializer)`.

## Supported direct, non-member, types

Let's think a scenario. What would happen if, instead of serializing a complex object, the user wants to serialize a single, primitive, value? Example: a `string`.

By default, strings do not implement `ISerializable` and cannot be encoded like this. However, this package provides a way to workaround for primitive values: `Wrapper` objects.

They're all located into the `AlephVault.Unity.Binary.Wrappers` namespace. All of the satisfy these properties:

1. They can be directly assigned via implicit cast, e.g. `bool value = myBoolWrapper`.
2. They must be explicitly cast the other way, e.g. `Bool myBoolWrapper = (Bool)value`.

Otherwise, they're standard `ISerializable` objects, fully implementing `Serialize`.

The available wrapper types, in the said namespace, are:

1. `Bool` for `bool`.
2. `Byte`, `SByte`, `Char` for `byte`, `sbyte` and `char` respectively.
3. In the same line, `Int` and `UInt` for `int` and `uint`.
4. In the same line, `Short` and `UShort` for `short` and `ushort`.
5. In the same line, `Long` and `ULong` for `long` and `ulong`.
6. There's also for fractional numbers: `Float` and `Double` for `float` and `double`.
7. `Color`, `Color32`, `Vector2`, `Vector3`, `Vector4`, `Quaternion`, `Ray` and `Ray2D` for Unity's `Color`, `Color32`, `Vector2`, `Vector3`, `Vector4`, `Quaternion`, `Ray` and `Ray2D` respectively.
8. `String` for `string`.
9. `Enum<T>` for a type `T` being an `enum`.
10. There's the ability to create a custom `Wrapper<T>` subclass, for any primitive type not included in this list.

## Temporary Buffers

If the users want to work with intermediate data, rather than sending the data to a stream directly, users can make use of `Buffer` instances. Buffers are streams and thus can be directly used when instantiating `Reader` and `Writer` objects.

Buffers can be instantiated like this:

```
using AlephVault.Unity.Binary;

Buffer b1 = new Buffer(); // Default initial capacity and grow factor.

Buffer b2 = new Buffer(5); // Given initial capacity, and default grow factor.

Buffer b3 = new Buffer(1.0); // Default initial capacity, and given grow factor.

Buffer b4 = new Buffer(5, 1.0); // Given initial capacity and grow factor.

Buffer b5 = new Buffer(new byte[100]); // An existing array (in this case, instantiated on the fly). The buffer will NOT grow. This last case is useful if we want to easily retrieve the buffer data, later, as a byte array.
```