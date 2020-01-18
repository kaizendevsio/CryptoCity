﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BlockchainTx;
//
//    var blockchainTx = BlockchainTx.FromJson(jsonString);

namespace CryptoCityWallet.ExternalUtilities.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class BlockchainTx
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("total_received")]
        public long TotalReceived { get; set; }

        [JsonProperty("total_sent")]
        public long TotalSent { get; set; }

        [JsonProperty("balance")]
        public long Balance { get; set; }

        [JsonProperty("unconfirmed_balance")]
        public long UnconfirmedBalance { get; set; }

        [JsonProperty("final_balance")]
        public long FinalBalance { get; set; }

        [JsonProperty("n_tx")]
        public long NTx { get; set; }

        [JsonProperty("unconfirmed_n_tx")]
        public long UnconfirmedNTx { get; set; }

        [JsonProperty("final_n_tx")]
        public long FinalNTx { get; set; }

        [JsonProperty("txrefs")]
        public List<Txref> Txrefs { get; set; }

        [JsonProperty("tx_url")]
        public Uri TxUrl { get; set; }
    }

    public partial class Txref
    {
        [JsonProperty("tx_hash")]
        public string TxHash { get; set; }

        [JsonProperty("block_height")]
        public long BlockHeight { get; set; }

        [JsonProperty("tx_input_n")]
        public long TxInputN { get; set; }

        [JsonProperty("tx_output_n")]
        public long TxOutputN { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
        public long ValueFiat { get; set; }

        [JsonProperty("ref_balance")]
        public long RefBalance { get; set; }

        [JsonProperty("confirmations")]
        public long Confirmations { get; set; }

        [JsonProperty("confirmed")]
        public DateTimeOffset Confirmed { get; set; }

        [JsonProperty("double_spend")]
        public bool DoubleSpend { get; set; }

        [JsonProperty("spent", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Spent { get; set; }

        [JsonProperty("spent_by", NullValueHandling = NullValueHandling.Ignore)]
        public string SpentBy { get; set; }
    }

    public partial class BlockchainTx
    {
        public static BlockchainTx FromJson(string json) => JsonConvert.DeserializeObject<BlockchainTx>(json, CryptoCityWallet.ExternalUtilities.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this BlockchainTx self) => JsonConvert.SerializeObject(self, CryptoCityWallet.ExternalUtilities.Models.Converter.Settings);
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
