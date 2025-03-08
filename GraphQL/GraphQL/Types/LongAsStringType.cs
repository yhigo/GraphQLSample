using HotChocolate.Language;
using System.Diagnostics.CodeAnalysis;

namespace GraphQLSample.API.GraphQL.Types
{
    public class LongAsStringType : ScalarType<long, StringValueNode>

    {
        public LongAsStringType()
            : base("Long", BindingBehavior.Implicit)
        {
            Description = "Long値をJSONでは文字列として扱うカスタムスカラー型";
        }

        protected override StringValueNode ParseValue(long runtimeValue)
        {
            // 値をLongから文字列に変換
            return new StringValueNode(runtimeValue.ToString());
        }

        public override IValueNode ParseResult(object? resultValue)
        {
            return ParseValue(resultValue);
        }

        // GraphQLクエリの入力値（文字列）をLong型に変換
        protected override long ParseLiteral(StringValueNode valueSyntax)
        {
            if (long.TryParse(valueSyntax.Value, out var longValue))
            {
                return longValue;
            }

            throw new SerializationException(
                $"Unable to deserialize string value '{valueSyntax.Value}' to a Long value.",
                this);
        }

        // レスポンスのシリアライズ時にLong型を文字列に変換
        public override bool TrySerialize(object? runtimeValue, out object? resultValue)
        {
            if (runtimeValue is null)
            {
                resultValue = null;
                return true;
            }

            if (runtimeValue is long longValue)
            {
                resultValue = longValue.ToString();
                return true;
            }

            resultValue = null;
            return false;
        }

        //// 文字列からLong型へのデシリアライズ
        public override bool TryDeserialize(object? resultValue, [NotNullWhen(true)] out object? runtimeValue)
        {
            if (resultValue is null)
            {
                runtimeValue = null;
                return false;
            }

            // 文字列の場合はLongに変換
            if (resultValue is string stringValue && long.TryParse(stringValue, out var longValue))
            {
                runtimeValue = longValue;
                return true;
            }

            // すでにLongの場合はそのまま返す
            if (resultValue is long longResult)
            {
                runtimeValue = longResult;
                return true;
            }

            runtimeValue = null;
            return false;
        }

    }
}
