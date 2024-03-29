﻿//
//  MarkdownImage.cs
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
/// Represents a markdown image.
/// </summary>
[PublicAPI]
public class MarkdownImage : MarkdownLink
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MarkdownImage"/> class.
    /// </summary>
    /// <param name="destination">The destination.</param>
    /// <param name="text">The visible text.</param>
    public MarkdownImage(string destination, string text)
        : base(destination, text)
    {
    }

    /// <inheritdoc />
    public override string Compile()
    {
        return string.IsNullOrWhiteSpace(this.Tooltip)
            ? $"![{this.Text}]({this.Destination})"
            : $"![{this.Text}]({this.Destination} \"{this.Tooltip}\")";
    }
}
