using MerlinCore.Voice;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Console = Colorful.Console;

namespace MerlinCore
{
    //Essa classe é responsável pela apresentação no console, estilizando e verificando autenticidade;
    public class MerlinInterface
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        MicrosoftSpechMerlinCore fh = new MicrosoftSpechMerlinCore();
        //---------------------------------------------------------------------------------
        //Mensagem padrão e senha de acesso
        //OBS: Deixei a senha de acesso aqui mesmo pois só irei usas esse programa no meu 
        //computador, então não faz tanta diferença.
        static string hello = "Olá! Bem vindo Fernando. Por Favor digite a senha de acesso";
        static string acess = "JKF186570";
        //---------------------------------------------------------------------------------
        //Em sequência, Verificação que é alterada para TRUE assim que a senha é colocada
        //para não ser solicitada novamente quando acontecer o loop de retorno da MERLIN;
        //
        public bool activate = false;
        public string key;
        static string result = null;
        static string[] comand = File.ReadAllLines(@"D:\MerlinDictionary\keywords.txt");

        //---------------------------------------------------------------------------------
        public void initial()
        {
            //Faz a verificação se a entrada de texto é o mesmo que a da chave de acesso caso
            //o activate seja falso;
            if (activate == false)
            {
                key = verification();
            }
            //Se o 'login' for bem sucedido todo o reconhecimento de voz e virificações são inicializados,
            //seta a chave 'activate' para true para pular a primeira verificação de login quando a aplicação
            //fizer loop;
            if (key == acess || activate == true)
            {
                activate = true;
                //Inicializa uma linha de comandos simples que pode ser usada para pedir os comandos do reconhecimento
                //ou para enviar um email;
                Console.WriteLine("OK! Digite Help Para Ver Todos os Comandos ou pressione enter.", Color.BlueViolet);
                Console.WriteLine("-----------------------------------------------------------", Color.Honeydew);
                result = Console.ReadLine();
                Console.WriteLine("-----------------------------------------------------------", Color.Honeydew);
                if (result == "Help" || result == "help")
                {
                    help();
                }
                else if (result == string.Empty) 
                {
                    Console.WriteLine("Estou Te Ouvindo", Color.Aqua);
                    Console.WriteLine("-----------------------------------------------------------", Color.Honeydew);
                    fh.inicializer();
                    string a = Console.ReadLine();
                    if(a != "help" || a != "Help" || a == null)
                    {
                        //Se for diferente de Help ele esconde o console e deixa rodando em segundo plano
                        fh.hide();
                        Console.Clear();
                        ret();
                    }
                    
                }
                else if (result == "email")
                {
                    EmailSending email = new EmailSending();
                    email.Email();
                    ret();
                }
                
            }
            else
            {
                hello = "Senha inválida";
                Console.Clear();
                ret();
            }
        }
        public void help()
        {
            
            Console.WriteLine("Command Lists", Color.AliceBlue);
            Console.WriteLine("-----------------------------------------------------------", Color.Honeydew);
            for (int i = 0; i < comand.Length; i++)
            {
                Console.WriteLine("--> " + comand[i], Color.MediumPurple);
                Console.WriteLine("-----------------------------------------------------------", Color.Honeydew);
            }
            result = "Continue";
        }
        public string verification()
        {

            Console.WriteLine(hello, Color.BlueViolet);
            Console.WriteLine("-----------------------------------------------------------", Color.Honeydew);
            string key = Console.ReadLine();
            Console.WriteLine("-----------------------------------------------------------", Color.Honeydew);
            return key;
        }
        public void ret()
        {
            initial();
        }
        public void urn()
        {

            fh.inicializer();
        }
    }
}
