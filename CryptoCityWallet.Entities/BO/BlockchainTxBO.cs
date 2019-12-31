namespace CryptoCityWallet.Entities.BO
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class BlockchainTxBO
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("totalReceived")]
        public long TotalReceived { get; set; }

        [JsonProperty("totalSent")]
        public long TotalSent { get; set; }

        [JsonProperty("balance")]
        public long Balance { get; set; }

        [JsonProperty("unconfirmedBalance")]
        public long UnconfirmedBalance { get; set; }

        [JsonProperty("finalBalance")]
        public long FinalBalance { get; set; }

        [JsonProperty("nTx")]
        public long NTx { get; set; }

        [JsonProperty("unconfirmedNTx")]
        public long UnconfirmedNTx { get; set; }

        [JsonProperty("finalNTx")]
        public long FinalNTx { get; set; }

        [JsonProperty("txrefs")]
        public List<Txref> Txrefs { get; set; }

        [JsonProperty("txUrl")]
        public Uri TxUrl { get; set; }
    }

    public partial class Txref
    {
        [JsonProperty("txHash")]
        public string TxHash { get; set; }

        [JsonProperty("blockHeight")]
        public long BlockHeight { get; set; }

        [JsonProperty("txInputN")]
        public long TxInputN { get; set; }

        [JsonProperty("txOutputN")]
        public long TxOutputN { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("refBalance")]
        public long RefBalance { get; set; }

        [JsonProperty("confirmations")]
        public long Confirmations { get; set; }

        [JsonProperty("confirmed")]
        public DateTimeOffset Confirmed { get; set; }

        [JsonProperty("doubleSpend")]
        public bool DoubleSpend { get; set; }

        [JsonProperty("spent")]
        public bool? Spent { get; set; }

        [JsonProperty("spentBy")]
        public string SpentBy { get; set; }
    }

    public partial class BlockchainTxBO
    {
        public static BlockchainTxBO FromJson(string json) => JsonConvert.DeserializeObject<BlockchainTxBO>(json, CryptoCityWallet.Entities.BO.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this BlockchainTxBO self) => JsonConvert.SerializeObject(self, CryptoCityWallet.Entities.BO.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
