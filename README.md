# INI File Parser

A .NET Standard library for reading/writing INI data from IO streams, file streams, and strings. 

Also implements merging operations, both for complete ini files, sections, or even just a subset of the keys contained by the files.

Install it with NuGet: https://www.nuget.org/packages/IniFileParserStandard/

## Getting Started

All code examples expect the following using clauses:

```csharp
using IniParser;
using IniParser.Model;
```

INI data is stored in nested dictionaries, so accessing the value associated to a key in a section is straightforward. Load the data using one of the provided methods.

```csharp
var parser = new IniFileParser();
IniData data = parser.ReadFile("Configuration.ini");
```

Retrieve the value for a key inside of a named section. Values are always retrieved as `string`s.

```csharp
string useFullScreenStr = data["UI"]["fullscreen"];
// useFullScreenStr contains "true"
bool useFullScreen = bool.Parse(useFullScreenStr);
```

Modify the value in the dictionary, not the value retrieved, and save to a new file or overwrite.

```csharp
data["UI"]["fullscreen"] = "true";
parser.WriteFile("Configuration.ini", data);
```

## Merging ini files
Merging ini files is a one-method operation:

```csharp

   var parser = new IniStringParser();

   IniData config = parser.Parse(File.ReadAllText("global_config.ini"));
   IniData user_config = parser.Parse(File.ReadAllText("user_config.ini"));
   config.Merge(user_config);

   // config now contains that data from both ini files, and the values of
   // the keys and sections are overwritten with the values of the keys and
   // sections that also existed in the user config file
```

Keep in mind that you can merge individual sections if you like:

```csharp
config["user_settings"].Merge(user_config["user_settings"]);
```

## Comments

The library allows modifying the comments from an ini file. 
However note than writing the file back to disk, the comments will be rearranged so 
comments are written before the element they refer to.

To query, add or remove comments, access the property `Comments` available both in `SectionData` and `KeyData` models.

```csharp
var listOfCommentsForSection = config.["user_settings"].Comments;
var listOfCommentsForKey = config["user_settings"].GetKeyData("resolution").Comments;
```