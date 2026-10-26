using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class PeppolScheme : DtoProviderBase
    {
        public string endpoint
        {
            get => Get<string>();
            set => Set(value);
        }

        public string partyIdentification
        {
            get => Get<string>();
            set => Set(value);
        }

        public string partyLegal
        {
            get => Get<string>();
            set => Set(value);
        }
    }
}
