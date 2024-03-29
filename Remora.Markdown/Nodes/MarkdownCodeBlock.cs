﻿//
//  MarkdownCodeBlock.cs
//
//  Author:
//       Jarl Gullberg <jarl.gullberg@gmail.com>
//
//  Copyright (c) Jarl Gullberg
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

using JetBrains.Annotations;

namespace Remora.Markdown;

/// <summary>
/// Represents a markdown code block with syntax highlighting.
/// </summary>
[PublicAPI]
public class MarkdownCodeBlock : IMarkdownNode
{
    /// <summary>
    /// Gets the code content.
    /// </summary>
    public IMarkdownNode Content { get; }

    /// <summary>
    /// Gets the syntax highlighting to use.
    /// </summary>
    public string? Highlighting { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MarkdownCodeBlock"/> class.
    /// </summary>
    /// <param name="content">The contents of the block.</param>
    /// <param name="highlighting">The highlighting to use, if any.</param>
    public MarkdownCodeBlock(IMarkdownNode content, string? highlighting = null)
    {
        this.Content = content;
        this.Highlighting = highlighting;
    }

    /// <inheritdoc />
    public string Compile()
    {
        return this.Highlighting is null
            ? $"```\n{this.Content.Compile()}\n```"
            : $"```{this.Highlighting}\n{this.Content.Compile()}\n```";
    }
}
