using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    public class Utilities
    {
        public static string FormatErrorMessage(string rawErrorMessage)
        {
            try
            {
                // Encontra a posição do início da mensagem JSON
                int startIndex = rawErrorMessage.IndexOf("{\"Message\":\"");

                // Se encontrar o início da mensagem JSON, extrai apenas a mensagem
                if (startIndex >= 0)
                {
                    // Remove a parte inicial indesejada
                    rawErrorMessage = rawErrorMessage.Substring(startIndex + "{\"Message\":\"".Length);

                    // Encontra o final da mensagem JSON
                    int endIndex = rawErrorMessage.IndexOf("\"}");

                    // Se encontrar o final da mensagem JSON, extrai apenas a mensagem
                    if (endIndex >= 0)
                    {
                        rawErrorMessage = rawErrorMessage.Substring(0, endIndex);
                    }
                }
                return rawErrorMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
