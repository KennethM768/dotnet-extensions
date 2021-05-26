﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tingle.Extensions.Json
{
    /// <summary>
    /// A <see cref="JsonConverter{T}"/> for <see cref="Version"/>
    /// </summary>
    public class VersionConverter : JsonConverter<Version>
    {
        /// <inheritdoc/>
        public override Version Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // only support from string
            if (reader.TokenType == JsonTokenType.String)
            {
                var s = reader.GetString();
                return Version.Parse(s);
            }

            return default;
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, Version value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            writer.WriteStringValue(value.ToString());
        }
    }
}
