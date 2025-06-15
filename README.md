# Common Extensions

This library contains a set of **common C# extension methods** designed to simplify daily coding tasks.  
The main purpose is to provide convenient, reusable functionality for **collections**, **dates**, **enums**, and **strings** — reducing boilerplate and improving code readability.

## ⚙ Main Features

### 1️ **StringExtensions**
- **SplitCamelCase:** Adds spaces to split concatenated words in a PascalCase or camelCase string.  
  **Example:**  
  ` "HelloWorld".SplitCamelCase()` → **"Hello World"**

### 2️ **EnumExtensions**
- **GetDisplayName:** Retrieves `DisplayAttribute` if defined; falls back to `SplitCamelCase`.
- **GetIntValue:** Converts an `enum` to its underlying `int`.
- **GetDisplayNameAndNumber:** Combines `GetIntValue` and `GetDisplayName`.  
  **Example:**  
```csharp
public enum Color { [Display(Name = "Bright Red")] Red }
Color.Red.GetDisplayNameAndNumber() // "0 (Bright Red)"
```

### 3️ **DateTimeExtensions**
- **ToFormattedString:** Formats `DateTime` or `nullable DateTime` into a specified pattern.  
- Supports ISO, 24-hour, 12-hour, Date-only, and Time-only formats.

```csharp
dateTime.ToFormattedString(DateTimeExtensions.DateTimeFormatType.Iso8601);
```

| Format Type | Method | Example |
|------------|---------|---------|
| **Iso8601** | `now.ToFormattedString(DateTimeExtensions.DateTimeFormatType.Iso8601)` | `2025-04-15T18:30:00` |
| **DateOnly** | `now.ToFormattedString(DateTimeExtensions.DateTimeFormatType.DateOnly)` | `2025-04-15` |
| **DateTime24H** | `now.ToFormattedString(DateTimeExtensions.DateTimeFormatType.DateTime24H)` | `2025-04-15 18:30` |
| **DateTime12H** | `now.ToFormattedString(DateTimeExtensions.DateTimeFormatType.DateTime12H)` | `2025-04-15 06:30 PM` |
| **TimeOnly** | `now.ToFormattedString(DateTimeExtensions.DateTimeFormatType.TimeOnly)` | `18:30` |
```

✅ **Tip:**  
- `ToFormattedString` gracefully handles `nullable DateTime` as well.  
```csharp
DateTime? nullableTime = now;
string formatted = nullableTime.ToFormattedString(DateTimeExtensions.DateTimeFormatType.DateTime24H);

### 4️ **CollectionExtensions**
- **AddRangeSafe:** Adds multiple items while avoiding duplicates.
- **RemoveRangeSafe:** Removes a range of items safely, ignoring non-existing ones.
- **SyncWithKeys:** Synchronises a collection based on a set of keys — removing, adding, or retaining items.

```csharp
existingItems.SyncWithKeys(newKeys, item => item.Id, key => new Item { Id = key });
```

## 🟣 Summary

This collection of extension methods aims to:
- Reduce code redundancy.
- Provide convenient and reusable functionality across projects.
- Handle common scenarios gracefully (like duplicates, `null` checks, formatting, and validation).

---

✅ **Suitable for:**  
- ASP.NET Core backends
- Console applications
- Utilities and libraries that need lightweight helper methods
