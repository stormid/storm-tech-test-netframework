using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards
{
	public class HearthstoneCardsTypeConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
		    serializer.Serialize(writer, value);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null) return null;

			var o = JArray.Load(reader);
			return o.Select(item => serializer.Deserialize<ICard>(item.CreateReader())).ToList();
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(IEnumerable<ICard>).IsAssignableFrom(objectType);
		}
	}
}