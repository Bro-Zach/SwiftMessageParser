using SwiftMessageParser.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SwiftMessageParser.Entities.MT.Tags
{
    public class TagFactory
    {
        private Dictionary<string, Type> _mappings;
        private Dictionary<string, string> _swiftTagToITagMapping;

        public TagFactory()
        {
            this.LoadITagDataTypes();
            this.LoadTagToClassMappings();
        }

        public List<ITag> CreateInstance(string parsedSwiftTag, List<ITag> listOfITags)
        {
            Type itagToCreate = this.GetITagToCreate(parsedSwiftTag.Substring(1, 3).TrimColon());
            if (itagToCreate != null)
            {
                ITag instance = Activator.CreateInstance(itagToCreate) as ITag;
                instance.GetTagValues(parsedSwiftTag);
                listOfITags.Add(instance);
            }
            return listOfITags;
        }

        private Type GetITagToCreate(string iTagToInstatiate)
        {
            foreach (KeyValuePair<string, string> keyValuePair in (IEnumerable<KeyValuePair<string, string>>)this._swiftTagToITagMapping.OrderBy<KeyValuePair<string, string>, string>((Func<KeyValuePair<string, string>, string>)(tm => tm.Key)))
            {
                if (keyValuePair.Key == iTagToInstatiate)
                    iTagToInstatiate = this._swiftTagToITagMapping[keyValuePair.Key];
            }
            foreach (KeyValuePair<string, Type> keyValuePair in (IEnumerable<KeyValuePair<string, Type>>)this._mappings.OrderBy<KeyValuePair<string, Type>, string>((Func<KeyValuePair<string, Type>, string>)(map => map.Key)))
            {
                if (keyValuePair.Key.Contains(iTagToInstatiate.ToUpper()))
                    return this._mappings[keyValuePair.Key];
            }
            return (Type)null;
        }

        private void LoadITagDataTypes()
        {
            this._mappings = new Dictionary<string, Type>();
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.GetInterface(typeof(ITag).ToString()) != null)
                    this._mappings.Add(type.Name.ToUpper(), type);
            }
        }

        private void LoadTagToClassMappings()
        {
            this._swiftTagToITagMapping = new Dictionary<string, string>();
            this._swiftTagToITagMapping.Add("11A", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("12C", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("13A", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("13J", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("17B", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("20C", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("20D", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("22H", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("36C", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("69J", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("70C", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("70E", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("90E", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("92A", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("92K", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("94C", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("95C", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("95P", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("95Q", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("97A", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("97C", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("98A", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("98C", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("99A", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("99B", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("32B", "PatternCurrencyAmount");
            this._swiftTagToITagMapping.Add("32G", "PatternCurrencyAmount");
            this._swiftTagToITagMapping.Add("32M", "PatternCurrencyAmount");
            this._swiftTagToITagMapping.Add("32U", "PatternCurrencyAmount");
            this._swiftTagToITagMapping.Add("33B", "PatternCurrencyAmount");
            this._swiftTagToITagMapping.Add("33E", "PatternCurrencyAmount");
            this._swiftTagToITagMapping.Add("33F", "PatternCurrencyAmount");
            this._swiftTagToITagMapping.Add("34B", "PatternCurrencyAmount");
            this._swiftTagToITagMapping.Add("71F", "PatternCurrencyAmount");
            this._swiftTagToITagMapping.Add("71G", "PatternCurrencyAmount");
            this._swiftTagToITagMapping.Add("71H", "PatternCurrencyAmount");
            this._swiftTagToITagMapping.Add("71J", "PatternCurrencyAmount");
            this._swiftTagToITagMapping.Add("71K", "PatternCurrencyAmount");
            this._swiftTagToITagMapping.Add("71L", "PatternCurrencyAmount");
            this._swiftTagToITagMapping.Add("12A", "PatternOptionalCode");
            this._swiftTagToITagMapping.Add("12B", "PatternOptionalCode");
            this._swiftTagToITagMapping.Add("13B", "PatternOptionalCode");
            this._swiftTagToITagMapping.Add("25D", "PatternOptionalCode");
            this._swiftTagToITagMapping.Add("22F", "PatternOptionalCode");
            this._swiftTagToITagMapping.Add("24B", "PatternOptionalCode");
            this._swiftTagToITagMapping.Add("38B", "PatternOptionalCode");
            this._swiftTagToITagMapping.Add("92C", "PatternOptionalCode");
            this._swiftTagToITagMapping.Add("93A", "PatternOptionalCode");
            this._swiftTagToITagMapping.Add("94D", "PatternOptionalCode");
            this._swiftTagToITagMapping.Add("94F", "PatternOptionalCode");
            this._swiftTagToITagMapping.Add("98B", "PatternOptionalCode");
            this._swiftTagToITagMapping.Add("12", "PatternGetReference");
            this._swiftTagToITagMapping.Add("12E", "PatternGetReference");
            this._swiftTagToITagMapping.Add("12F", "PatternGetReference");
            this._swiftTagToITagMapping.Add("13E", "PatternGetReference");
            this._swiftTagToITagMapping.Add("14", "PatternGetReference");
            this._swiftTagToITagMapping.Add("14C", "PatternGetReference");
            this._swiftTagToITagMapping.Add("14D", "PatternGetReference");
            this._swiftTagToITagMapping.Add("14F", "PatternGetReference");
            this._swiftTagToITagMapping.Add("14J", "PatternGetReference");
            this._swiftTagToITagMapping.Add("14S", "PatternGetReference");
            this._swiftTagToITagMapping.Add("16A", "PatternGetReference");
            this._swiftTagToITagMapping.Add("16R", "PatternGetReference");
            this._swiftTagToITagMapping.Add("16S", "PatternGetReference");
            this._swiftTagToITagMapping.Add("17A", "PatternGetReference");
            this._swiftTagToITagMapping.Add("17F", "PatternGetReference");
            this._swiftTagToITagMapping.Add("17G", "PatternGetReference");
            this._swiftTagToITagMapping.Add("17N", "PatternGetReference");
            this._swiftTagToITagMapping.Add("17O", "PatternGetReference");
            this._swiftTagToITagMapping.Add("17R", "PatternGetReference");
            this._swiftTagToITagMapping.Add("17T", "PatternGetReference");
            this._swiftTagToITagMapping.Add("17U", "PatternGetReference");
            this._swiftTagToITagMapping.Add("17V", "PatternGetReference");
            this._swiftTagToITagMapping.Add("18A", "PatternGetReference");
            this._swiftTagToITagMapping.Add("19", "PatternGetReference");
            this._swiftTagToITagMapping.Add("20", "PatternGetReference");
            this._swiftTagToITagMapping.Add("21", "PatternGetReference");
            this._swiftTagToITagMapping.Add("21A", "PatternGetReference");
            this._swiftTagToITagMapping.Add("21B", "PatternGetReference");
            this._swiftTagToITagMapping.Add("21C", "PatternGetReference");
            this._swiftTagToITagMapping.Add("21D", "PatternGetReference");
            this._swiftTagToITagMapping.Add("21E", "PatternGetReference");
            this._swiftTagToITagMapping.Add("21F", "PatternGetReference");
            this._swiftTagToITagMapping.Add("21G", "PatternGetReference");
            this._swiftTagToITagMapping.Add("21N", "PatternGetReference");
            this._swiftTagToITagMapping.Add("21P", "PatternGetReference");
            this._swiftTagToITagMapping.Add("21R", "PatternGetReference");
            this._swiftTagToITagMapping.Add("22A", "PatternGetReference");
            this._swiftTagToITagMapping.Add("22B", "PatternGetReference");
            this._swiftTagToITagMapping.Add("22D", "PatternGetReference");
            this._swiftTagToITagMapping.Add("22E", "PatternGetReference");
            this._swiftTagToITagMapping.Add("22G", "PatternGetReference");
            this._swiftTagToITagMapping.Add("22J", "PatternGetReference");
            this._swiftTagToITagMapping.Add("22X", "PatternGetReference");
            this._swiftTagToITagMapping.Add("23B", "PatternGetReference");
            this._swiftTagToITagMapping.Add("23D", "PatternGetReference");
            this._swiftTagToITagMapping.Add("25", "PatternGetReference");
            this._swiftTagToITagMapping.Add("26E", "PatternGetReference");
            this._swiftTagToITagMapping.Add("26F", "PatternGetReference");
            this._swiftTagToITagMapping.Add("26H", "PatternGetReference");
            this._swiftTagToITagMapping.Add("26T", "PatternGetReference");
            this._swiftTagToITagMapping.Add("29C", "PatternGetReference");
            this._swiftTagToITagMapping.Add("29H", "PatternGetReference");
            this._swiftTagToITagMapping.Add("30", "PatternGetReference");
            this._swiftTagToITagMapping.Add("30F", "PatternGetReference");
            this._swiftTagToITagMapping.Add("30H", "PatternGetReference");
            this._swiftTagToITagMapping.Add("30P", "PatternGetReference");
            this._swiftTagToITagMapping.Add("30Q", "PatternGetReference");
            this._swiftTagToITagMapping.Add("30T", "PatternGetReference");
            this._swiftTagToITagMapping.Add("30U", "PatternGetReference");
            this._swiftTagToITagMapping.Add("30V", "PatternGetReference");
            this._swiftTagToITagMapping.Add("30X", "PatternGetReference");
            this._swiftTagToITagMapping.Add("31C", "PatternGetReference");
            this._swiftTagToITagMapping.Add("31E", "PatternGetReference");
            this._swiftTagToITagMapping.Add("31L", "PatternGetReference");
            this._swiftTagToITagMapping.Add("31S", "PatternGetReference");
            this._swiftTagToITagMapping.Add("32E", "PatternGetReference");
            this._swiftTagToITagMapping.Add("32J", "PatternGetReference");
            this._swiftTagToITagMapping.Add("35", "PatternGetReference");
            this._swiftTagToITagMapping.Add("35C", "PatternGetReference");
            this._swiftTagToITagMapping.Add("35D", "PatternGetReference");
            this._swiftTagToITagMapping.Add("36", "PatternGetReference");
            this._swiftTagToITagMapping.Add("36A", "PatternGetReference");
            this._swiftTagToITagMapping.Add("37J", "PatternGetReference");
            this._swiftTagToITagMapping.Add("37L", "PatternGetReference");
            this._swiftTagToITagMapping.Add("37P", "PatternGetReference");
            this._swiftTagToITagMapping.Add("37U", "PatternGetReference");
            this._swiftTagToITagMapping.Add("38A", "PatternGetReference");
            this._swiftTagToITagMapping.Add("38D", "PatternGetReference");
            this._swiftTagToITagMapping.Add("38E", "PatternGetReference");
            this._swiftTagToITagMapping.Add("39B", "PatternGetReference");
            this._swiftTagToITagMapping.Add("40A", "PatternGetReference");
            this._swiftTagToITagMapping.Add("40F", "PatternGetReference");
            this._swiftTagToITagMapping.Add("43P", "PatternGetReference");
            this._swiftTagToITagMapping.Add("43T", "PatternGetReference");
            this._swiftTagToITagMapping.Add("44A", "PatternGetReference");
            this._swiftTagToITagMapping.Add("44B", "PatternGetReference");
            this._swiftTagToITagMapping.Add("44C", "PatternGetReference");
            this._swiftTagToITagMapping.Add("44E", "PatternGetReference");
            this._swiftTagToITagMapping.Add("44F", "PatternGetReference");
            this._swiftTagToITagMapping.Add("49", "PatternGetReference");
            this._swiftTagToITagMapping.Add("50L", "PatternGetReference");
            this._swiftTagToITagMapping.Add("70", "PatternGetReference");
            this._swiftTagToITagMapping.Add("71A", "PatternGetReference");
            this._swiftTagToITagMapping.Add("94A", "PatternGetReference");
            this._swiftTagToITagMapping.Add("50A", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("50G", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("50H", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("50K", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("50F", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("52A", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("52D", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("52G", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("53A", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("53B", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("53D", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("54A", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("54B", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("54D", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("55A", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("55D", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("56A", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("56D", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("57A", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("57D", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("58A", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("58D", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("59", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("59A", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("59F", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("61", "PatternDoubleSlashSeperator");
            this._swiftTagToITagMapping.Add("82A", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("82B", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("82D", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("83A", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("83D", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("84A", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("84D", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("86", "PatternSlashConditionalLines");
            this._swiftTagToITagMapping.Add("32A", "PatternYYMMDDCurrencyAmount");
            this._swiftTagToITagMapping.Add("32C", "PatternYYMMDDCurrencyAmount");
            this._swiftTagToITagMapping.Add("32D", "PatternYYMMDDCurrencyAmount");
            this._swiftTagToITagMapping.Add("32P", "PatternYYMMDDCurrencyAmount");
            this._swiftTagToITagMapping.Add("33A", "PatternYYMMDDCurrencyAmount");
            this._swiftTagToITagMapping.Add("33C", "PatternYYMMDDCurrencyAmount");
            this._swiftTagToITagMapping.Add("33D", "PatternYYMMDDCurrencyAmount");
            this._swiftTagToITagMapping.Add("33P", "PatternYYMMDDCurrencyAmount");
            this._swiftTagToITagMapping.Add("33R", "PatternYYMMDDCurrencyAmount");
            this._swiftTagToITagMapping.Add("34A", "PatternYYMMDDCurrencyAmount");
            this._swiftTagToITagMapping.Add("34P", "PatternYYMMDDCurrencyAmount");
            this._swiftTagToITagMapping.Add("34R", "PatternYYMMDDCurrencyAmount");
            this._swiftTagToITagMapping.Add("13K", "PatternDoubleSlashTypeQuantity");
            this._swiftTagToITagMapping.Add("36B", "PatternDoubleSlashTypeQuantity");
            this._swiftTagToITagMapping.Add("90A", "PatternDoubleSlashTypeQuantity");
            this._swiftTagToITagMapping.Add("94B", "PatternOptionalCodeWithOptionalNarrative");
            this._swiftTagToITagMapping.Add("97B", "PatternOptionalCodeWithOptionalNarrative");
            this._swiftTagToITagMapping.Add("19A", "PatternSignCurrencyAmount");
            this._swiftTagToITagMapping.Add("19B", "PatternSignCurrencyAmount");
            this._swiftTagToITagMapping.Add("32H", "PatternSignCurrencyAmount");
            this._swiftTagToITagMapping.Add("14G", "PatternSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("23A", "PatternSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("27", "PatternSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("28D", "PatternSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("28E", "PatternSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("29E", "PatternSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("29K", "PatternSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("30G", "PatternSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("32Q", "PatternSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("38G", "PatternSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("38H", "PatternSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("39A", "PatternSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("15A", "PatternSequenceSeperator");
            this._swiftTagToITagMapping.Add("15B", "PatternSequenceSeperator");
            this._swiftTagToITagMapping.Add("15C", "PatternSequenceSeperator");
            this._swiftTagToITagMapping.Add("15D", "PatternSequenceSeperator");
            this._swiftTagToITagMapping.Add("15E", "PatternSequenceSeperator");
            this._swiftTagToITagMapping.Add("15F", "PatternSequenceSeperator");
            this._swiftTagToITagMapping.Add("15G", "PatternSequenceSeperator");
            this._swiftTagToITagMapping.Add("15H", "PatternSequenceSeperator");
            this._swiftTagToITagMapping.Add("15I", "PatternSequenceSeperator");
            this._swiftTagToITagMapping.Add("15J", "PatternSequenceSeperator");
            this._swiftTagToITagMapping.Add("15K", "PatternSequenceSeperator");
            this._swiftTagToITagMapping.Add("15L", "PatternSequenceSeperator");
            this._swiftTagToITagMapping.Add("15M", "PatternSequenceSeperator");
            this._swiftTagToITagMapping.Add("15N", "PatternSequenceSeperator");
            this._swiftTagToITagMapping.Add("22K", "PatternOptionalSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("23C", "PatternOptionalSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("23E", "PatternOptionalSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("23F", "PatternOptionalSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("24D", "PatternOptionalSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("25A", "PatternOptionalSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("26N", "PatternOptionalSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("26P", "PatternOptionalSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("28", "PatternOptionalSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("28C", "PatternOptionalSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("29J", "PatternOptionalSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("31R", "PatternOptionalSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("40C", "PatternOptionalSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("40E", "PatternOptionalSingleSlashSeperator");
            this._swiftTagToITagMapping.Add("29A", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("29B", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("29F", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("35E", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("35F", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("35L", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("37N", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("39C", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("40B", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("42C", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("42M", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("42P", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("44D", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("45A", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("45B", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("46A", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("46B", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("47A", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("47B", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("48", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("50", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("73", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("74", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("75", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("76", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("80C", "PatternGetAllLines");
            this._swiftTagToITagMapping.Add("32F", "PatternNNNValue");
            this._swiftTagToITagMapping.Add("33S", "PatternNNNValue");
            this._swiftTagToITagMapping.Add("33T", "PatternNNNValue");
            this._swiftTagToITagMapping.Add("35A", "PatternNNNValue");
            this._swiftTagToITagMapping.Add("35S", "PatternNNNValue");
            this._swiftTagToITagMapping.Add("90B", "PatternAmountTypeCurrencyValue");
            this._swiftTagToITagMapping.Add("95R", "PatternCodeWithNarrative");
            this._swiftTagToITagMapping.Add("39P", "PatternQualifierSlashCurrencyAmount");
            this._swiftTagToITagMapping.Add("51C", "PatternPrecedingSlash");
            this._swiftTagToITagMapping.Add("52C", "PatternPrecedingSlash");
            this._swiftTagToITagMapping.Add("53C", "PatternPrecedingSlash");
            this._swiftTagToITagMapping.Add("56C", "PatternPrecedingSlash");
            this._swiftTagToITagMapping.Add("57C", "PatternPrecedingSlash");
            this._swiftTagToITagMapping.Add("58C", "PatternPrecedingSlash");
            this._swiftTagToITagMapping.Add("83C", "PatternPrecedingSlash");
            this._swiftTagToITagMapping.Add("23G", "PatternOptionalSubFunction");
        }
    }
}
