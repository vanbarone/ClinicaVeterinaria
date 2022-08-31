using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace APIMaisEventos.Utils
{
    //Singleton - static
    public static class Upload
    {
        public static string UploadFile(IFormFile arquivo, string diretorio, string[] extensoesPermitidas)
        {
            try
            {
                //determina onde será salvo o arquivo
                string pasta = Path.Combine("StaticFiles", diretorio);
                string path = Path.Combine(Directory.GetCurrentDirectory(), pasta);

                //verifica se algum arquivo foi informado
                if (arquivo.Length > 0)
                {
                    //pega o nome do arquivo
                    string nomeArquivo = ContentDispositionHeaderValue.Parse(arquivo.ContentDisposition).FileName.Trim('"');

                    //valida se a extensão é permitida
                    if (ValidarExtensao(nomeArquivo, extensoesPermitidas))
                    {
                        string extensao = RetornarExtensao(nomeArquivo);
                        string novoNome = $"{Guid.NewGuid()}.{extensao}";
                        string pathCompleto = Path.Combine(path, novoNome);

                        using (FileStream stream = new FileStream(pathCompleto, FileMode.Create))
                        {
                            arquivo.CopyTo(stream);
                        }

                        return novoNome;
                    }
                }

                return "";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public static bool ValidarExtensao(string nomeArquivo, string[] extensoesPermitidas)
        {
            string extensao = RetornarExtensao(nomeArquivo);

            foreach (string ext in extensoesPermitidas)
            {
                if (ext == extensao)
                {
                    return true;
                }
            }

            return false;
        }

        public static string RetornarExtensao(string nomeArquivo)
        {
            string[] dados = nomeArquivo.Split('.');

            return dados[dados.Length - 1];
        }
    }
}