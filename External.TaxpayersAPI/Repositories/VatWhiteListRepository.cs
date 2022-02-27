using External.TaxpayersAPI.Exceptions;
using External.TaxpayersAPI.Models;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace External.TaxpayersAPI.Repositories
{
    internal sealed class VatWhiteListRepository : IVatWhiteListRepository
    {
        private const string url = "https://wl-api.mf.gov.pl";
        private const string nips = "6770065406,5242106963,8491587992";
        private readonly string dateTime = DateTime.UtcNow.ToString("yyyy-MM-dd");

        private JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        private readonly HttpClient _httpClient;

        public VatWhiteListRepository(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(url);
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Taxpayer>> GetAsync()
        {
            var stringResult = string.Empty;

            try
            {
                var result = await _httpClient.GetAsync($"/api/search/nips/{nips}?date={dateTime}");

                stringResult = await result.Content.ReadAsStringAsync();

                //stringResult = "{\"result\":{\"entries\":[{\"identifier\":\"6770065406\",\"subjects\":[{\"name\":\"COMARCH SPÓŁKA AKCYJNA\",\"nip\":\"6770065406\",\"statusVat\":\"Czynny\",\"regon\":\"350527377\",\"pesel\":null,\"krs\":\"0000057567\",\"residenceAddress\":null,\"workingAddress\":\"AL. JANA PAWŁA II 39A, 31-864 KRAKÓW\",\"representatives\":[],\"authorizedClerks\":[],\"partners\":[],\"registrationLegalDate\":\"2000-07-01\",\"registrationDenialBasis\":null,\"registrationDenialDate\":null,\"restorationBasis\":null,\"restorationDate\":null,\"removalBasis\":null,\"removalDate\":null,\"accountNumbers\":[\"49124047221111000048528672\",\"02160011980002002251087001\",\"03114010810000229060001002\",\"03239000040011000000008177\",\"05114010100000229060004010\",\"05219000023000004622800101\",\"06160011980002002251087026\",\"07103011880000000091894012\",\"08102028920000510202541662\",\"08124047221111000048511368\",\"08160010710003011250558001\",\"11114010100000229060020004\",\"12124047221978000048511111\",\"15160011980002002251087155\",\"16114010100000229060017004\",\"17124061751111001065330514\",\"18160011980002002251087198\",\"19124047221787000048557395\",\"21219000023000004622800201\",\"22102010260000120203035276\",\"23103011880000000091894015\",\"24124062921111001076119234\",\"26160011980002002251087151\",\"27105000861000009030156906\",\"33160011980002002251087025\",\"34103011880000000091894011\",\"34114010100000229060006010\",\"37102028920000580202541670\",\"37219000023000004622800301\",\"38239000040011000000008808\",\"39114010100000229060003010\",\"40114010100000229060022004\",\"43160011980002002250558001\",\"44103011880000000091894025\",\"44114010100000229060013008\",\"45124062921111001068296679\",\"46114010100000229060002011\",\"46114010810000229060001004\",\"46160014620008811251087140\",\"49105000861000009030156898\",\"49114010100000229060023006\",\"50103011880000000091894014\",\"50114010100000229060016004\",\"51114000390000229060024002\",\"53124062921789001042845822\",\"58105000861000009030124144\",\"58160014620008811251087021\",\"60160011980002002251087024\",\"60249000050000453014549972\",\"60249000050000460088822246\",\"61103011880000000091894010\",\"62105000861000009030124169\",\"62249000050000460037822132\",\"63105000861000009030124151\",\"63114010100000229060008010\",\"63124062921781001091991480\",\"66103011880000000091894017\",\"66150011421211400586770000\",\"67114010100000229060012012\",\"68114010100000229060005010\",\"69219000023000004622800501\",\"70114010100000229060007011\",\"72249000050000460026829136\",\"73114010100000229060015008\",\"73114010810000229060001003\",\"74114010100000229060011013\",\"74114010100000229060021004\",\"74249000050000460039448412\",\"75124062921111001027205193\",\"75124062921201001069869441\",\"76102028920000580202541647\",\"77103011880000000091894013\",\"78114010100000229060009001\",\"79114010100000229060018004\",\"79124062921797001042846021\",\"83124062921978001082489141\",\"84124062921792001042846278\",\"84124062921798001042846366\",\"85160011980002002251087156\",\"88103011880000000091894009\",\"88114010100000229060019006\",\"91249000050000460015409372\",\"92114010100000229060010010\",\"92124047221111000048554961\",\"92160011980002002251087030\",\"93116022020000000159572569\",\"96114010100000229060014012\",\"96124062921788001039484630\",\"97124062921111001036558992\",\"10114000390000229060026001\",\"44114000390000229060025001\",\"73114000390000229060027001\",\"14124062921111001108699871\",\"15102010260000130204925204\"],\"hasVirtualAccounts\":true}]},{\"identifier\":\"5242106963\",\"subjects\":[{\"name\":\"COCA-COLA HBC POLSKA SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ\",\"nip\":\"5242106963\",\"statusVat\":\"Czynny\",\"regon\":\"012833736\",\"pesel\":null,\"krs\":\"0000015664\",\"residenceAddress\":null,\"workingAddress\":\"ŻWIRKI I WIGURY 16, 02-092 WARSZAWA\",\"representatives\":[],\"authorizedClerks\":[],\"partners\":[],\"registrationLegalDate\":\"2003-12-31\",\"registrationDenialBasis\":null,\"registrationDenialDate\":null,\"restorationBasis\":null,\"restorationDate\":null,\"removalBasis\":null,\"removalDate\":null,\"accountNumbers\":[\"15103015080000000501429368\",\"21103015080000000501429066\",\"34103015080000000501429414\",\"62103015080000000501429007\"],\"hasVirtualAccounts\":true}]},{\"identifier\":\"8491587992\",\"subjects\":[{\"name\":\"MUZEUM WOJSKA, WOJSKOWOŚCI I ZIEMI ORZYSZKIEJ W ORZYSZU (W ORGANIZACJI)\",\"nip\":\"8491587992\",\"statusVat\":\"Zwolniony\",\"regon\":\"362503261\",\"pesel\":null,\"krs\":null,\"residenceAddress\":null,\"workingAddress\":\"GIŻYCKA 9, 12-250 ORZYSZ\",\"representatives\":[],\"authorizedClerks\":[],\"partners\":[],\"registrationLegalDate\":\"2020-01-01\",\"registrationDenialBasis\":null,\"registrationDenialDate\":null,\"restorationBasis\":null,\"restorationDate\":null,\"removalBasis\":null,\"removalDate\":null,\"accountNumbers\":[\"57936400002003002956080001\"],\"hasVirtualAccounts\":false}]}],\"requestDateTime\":\"20-02-2022 17:35:37\",\"requestId\":\"8vJw8-8ef71h1\"}}";

                if (!result.IsSuccessStatusCode)
                {
                    var exception = JsonSerializer.Deserialize<ApiExceptionModel>(stringResult, jsonSerializerOptions);
                    throw new ApiException(exception.Code, exception.Message);
                }

                var vatWhiteListSearch = JObject.Parse(stringResult);
                var taxpayers = new List<Taxpayer>();

                foreach (var entry in vatWhiteListSearch["result"]["entries"])
                {
                    var entrySearch = JObject.Parse(entry.ToString());
                    var subject = entrySearch["subjects"].FirstOrDefault().ToString();
                    var taxpayer = JsonSerializer.Deserialize<Taxpayer>(subject, jsonSerializerOptions);

                    taxpayers.Add(taxpayer);
                }
                return taxpayers;
            }
            catch (Exception ex)
            {
                throw new VatWhiteListGetProblemException(ex.Message);
            }
        }
    }
}