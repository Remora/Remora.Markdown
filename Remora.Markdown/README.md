Remora.Markdown
===============

Remora.Markdown is a small, type-safe library for generating Markdown text. It 
uses a graph-oriented approach to build Markdown documents, letting you create
node trees of various syntax elements which can then be "compiled" into raw
textual output.

The library supports some common extensions to the Markdown format such as 
tables.

### Usage
Usage is relatively simple. If you wanted to create a section of Markdown text
with some content, for example, you might do something like this:

```csharp
var section = new MarkdownSection("My Section");
section
    .AppendContent(new MarkdownText("The contents of my section "))
    .AppendContent(new MarkdownLink("https://example.org", "with a link"))
    .AppendContent(new MarkdownHorizontalRule())
    .AppendContent(new MarkdownText("And here's a list of things:"))
    .AppendContent
    (
        new MarkdownList()
            .AppendItem(new MarkdownText("With emphasis!"){ Emphasis = EmphasisType.Bold | EmphasisType.Italic })
            .AppendItem(new MarkdownInlineCode("var snippet = value;"))
    );
    
var text = section.Compile();
```

This would compile into the following markdown:
```markdown
# My Section
The contents of my section [with a link](https://example.org)
---
And here's a list of things:
  * ***With emphasis!***
  * `var snippet = value`;
```

### Installation
Get it on NuGet!
