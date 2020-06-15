namespace AccessControl.BusinessRule.Models
{
    public class TokenResponse
    {
        private string token { get; set; }

        public TokenResponse(string token)
        {
            this.token = token;
        }

        public string Token { get { return token; } }
    }
}
