using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards
{
	public class HearthstoneCardTypeConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
		    serializer.Serialize(writer, value);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null || reader.TokenType != JsonToken.StartObject) return null;

			var item = JObject.Load(reader);
			CardTypeOptions cardType;
			if (Enum.TryParse(item["type"].Value<string>(), true, out cardType))
			{
				switch (cardType)
				{
					case CardTypeOptions.Minion:
						return item.ToObject<MinionCard>();
					case CardTypeOptions.Spell:
						return item.ToObject<SpellCard>();
					case CardTypeOptions.Weapon:
						return item.ToObject<WeaponCard>();
					case CardTypeOptions.Hero:
						return item.ToObject<HeroCard>();
				}
			}
			return null;
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(ICard).IsAssignableFrom(objectType);
		}
	}
}