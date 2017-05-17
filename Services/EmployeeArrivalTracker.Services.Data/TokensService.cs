namespace EmployeeArrivalTracker.Services.Data
{
    using EmployeeArrivalTracker.Data.Models;
    using EmployeeArrivalTracker.Data.Repositories;
    using System.Linq;

    public class TokensService
    {
        private readonly DbRepository<Token> tokensRepository;

        public TokensService()
        {
            this.tokensRepository = new DbRepository<Token>();
        }

        public void Add(Token token)
        {
            this.tokensRepository.Add(token);
        }

        public Token GetByContent(string content)
        {
            return this.tokensRepository.All().Where(t => t.Content == content).FirstOrDefault();
        }
    }
}
