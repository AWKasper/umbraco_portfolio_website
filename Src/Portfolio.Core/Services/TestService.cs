using System.Collections.Generic;
using System.Linq;

namespace Portfolio.Core.Services
{
    public interface ITestService
    {
        public List<string> GetAll();
        public void Add(string text);
    }
    public class TestService : ITestService
    {
        private readonly List<string> _texts = new List<string>();
        public List<string> GetAll()
        {
            return _texts.ToList();
        }
        public void Add(string text)
        {
            _texts.Add(text);
        }
    }
}