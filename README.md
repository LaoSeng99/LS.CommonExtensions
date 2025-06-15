# LS.CommonExtensions

This library provides a set of **C# extension methods** packaged as a NuGet utility for everyday .NET development — especially suitable for backend, utility layers, or enterprise projects.

## ⚙ Main Features

### 1️ **StringExtensions**
- **SplitCamelCase:** Adds spaces to split concatenated words in a PascalCase or camelCase string.  
  **Example:**  
  `"HelloWorld".SplitCamelCase()` → **"Hello World"**
- **ToTitleCase:** Converts all words' first letters to uppercase. Good for names and labels.
- **RemoveWhiteSpace:** Removes all whitespace characters.  
  Useful for comparing sanitized strings or URL keys.
- **ToSlug:** Converts to lowercase, hyphenated, URL-safe format.  
  Ideal for SEO slugs and clean routing paths.
- **MaskSensitive:** Obscures the middle portion of a string (like IC or phone numbers).
- **ContainsIgnoreCase:** Checks if one string contains another, case-insensitive.  
  Helpful for flexible search logic.

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
  Supports ISO, 24-hour, 12-hour, Date-only, and Time-only formats.

```csharp
dateTime.ToFormattedString(DateTimeExtensions.DateTimeFormatType.Iso8601);
```

| Format Type     | Method                                                             | Example Output         | Usage Context                      |
|-----------------|--------------------------------------------------------------------|-------------------------|-------------------------------------|
| **Iso8601**     | `now.ToFormattedString(DateTimeFormatType.Iso8601)`                | `2025-04-15T18:30:00`  | API / JSON serialization           |
| **DateOnly**    | `now.ToFormattedString(DateTimeFormatType.DateOnly)`              | `2025-04-15`           | UI, grid listing, DB filters       |
| **DateTime24H** | `now.ToFormattedString(DateTimeFormatType.DateTime24H)`           | `2025-04-15 18:30`     | Internal logs, system display      |
| **DateTime12H** | `now.ToFormattedString(DateTimeFormatType.DateTime12H)`           | `2025-04-15 06:30 PM`  | Human-readable forms               |
| **TimeOnly**    | `now.ToFormattedString(DateTimeFormatType.TimeOnly)`              | `18:30`                | Schedule pickers / compact UIs     |

✅ **Tip:**
- `ToFormattedString` gracefully handles `nullable DateTime`.

```csharp
DateTime? nullableTime = now;
string formatted = nullableTime.ToFormattedString(DateTimeFormatType.DateTime24H);
```

### 4️ **CollectionExtensions**
- **AddRangeSafe:** Adds multiple items while avoiding duplicates.  
  Useful for merging list results or appending config.
- **RemoveRangeSafe:** Removes a range safely, ignoring missing items.  
  Protects against exceptions during bulk updates.
- **SyncWithKeys:** Synchronises an in-memory collection from a new set of keys.  
  Helps in aligning EF Core tracked items or user-modified lists.

```csharp
existingItems.SyncWithKeys(newKeys, item => item.Id, key => new Item { Id = key });
```

### 5️ **IntExtensions**
- **IsPrime:** Returns true if the number is prime. Use in filtering or quizzes.
- **IsEven / IsOdd:** Checks number parity.  
  Can be useful in custom sorting, alternate row behavior.
- **Clamp:** Constrains a number within a min/max range.  
  Ideal for score validation, paging boundaries, or form inputs.
- **ToFileSizeString:** Converts byte-size to readable format like KB/MB.  
  Great for storage indicators.

### 6️ **LongExtensions**
- **ToFileSizeString:** Same as `Int`, but handles larger numbers (`long`).  
  Perfect for streaming files, attachments, system logs.

### 7️ **DecimalExtensions**
- **ToCurrencyString:** Formats to localized currency string.  
  E.g., `"RM1,000.00"` for `"ms-MY"`, or `"$1,000.00"` for `"en-US"`.

```csharp
1234.5m.ToCurrencyString(new CultureInfo("ms-MY")); // "RM1,234.50"
```

---

## 📦 Installation

```sh
dotnet add package LS.CommonExtensions
```
---

## ✅ Benefits

- 📦 Zero-dependency, drop-in helper methods
- 🚀 Faster utility-layer development
- 🎯 Clean C# API: `value.ExtensionMethod()` style

---

## 📄 License

MIT