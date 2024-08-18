using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambleMaticCommLib
{
    public class TokenHolder
    {

        public TokenHolder(ApiCommunicatorService apiCommunicatorService)
        {
            _apiCommunicatorService = apiCommunicatorService;
        }
        
        private string? _currentToken = null;
        private readonly ApiCommunicatorService _apiCommunicatorService;


    }





}
