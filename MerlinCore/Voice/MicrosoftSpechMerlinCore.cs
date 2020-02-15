using Microsoft.Speech.Recognition;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace MerlinCore.Voice
{
    public class MicrosoftSpechMerlinCore
    {
        //-------------------------------------------------------
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        //-------------------------------------------------------
        static SpeechRecognitionEngine src;
        public bool stop = false;
        public string acess { get; set; }
        //Carrega as bibliotecas que serão usadas no reconhecimento de voz e na execução de comandos.
        public string[] gramar = File.ReadAllLines(@"D:\MerlinDictionary\gramar.txt", Encoding.UTF8);
        public string[] keywords = File.ReadAllLines(@"D:\MerlinDictionary\keywords.txt", Encoding.UTF8);
        public string[] keywordscomands = File.ReadAllLines(@"D:\MerlinDictionary\comandkeywords.txt", Encoding.UTF8);
        //-------------------------------------------------------
        public void inicializer()
        {
                    //Adiciona as Bibliotecas nescessárias.
                    stop = true;
                    CultureInfo ci = new CultureInfo("pt-BR");
                    src = new SpeechRecognitionEngine();
                    var words = new Choices();
                    var wordsBuilder = new GrammarBuilder();
                    words.Add(gramar);
                    words.Add(keywords);
                    wordsBuilder.Append(words);
                    var w = new Grammar(wordsBuilder);
                    src.RequestRecognizerUpdate();
                    src.SpeechRecognized += Src_SpeechRecognized;
                    src.LoadGrammarAsync(w);
                    src.SetInputToDefaultAudioDevice();
                    src.RecognizeAsync(RecognizeMode.Multiple);
        }
        //---------------------------------------------------------------------------------
        //Inicializa o reconhecimento de voz e executa determinadas tarefas de acordo com o resultado
        private void Src_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
                functions(e.Result.Text);
        }
        //---------------------------------------------------------------------------------
        //Função que verifica se o Resultado do reconhecimento contém a palavra chave 'merlin'
        public void functions(string e)
        {
                verify(e);
        }
        //---------------------------------------------------------------------------------
        //Verifica qual das bibliotecas será usada através de palavras chaves.
        public void verify(string e)
        {   
            //Se não conter a palavra chave 'abre', significa que não é comando de abertura de arquivos, programas ou
            //sites.
            if (!e.Contains("merlin abre"))
            {
                if (e == gramar[1])
                {
                    MerlinInterface mf = new MerlinInterface();
                    mf.help();
                    return;
                }
                else if (e == gramar[2])
                {
                    hide();
                    return;
                }
                else if (e == gramar[3])
                {
                    show();
                    return;
                }
            }
            //Se conter a palavra chave 'abre', significa que é um comando de abertura e faz a execução de acordo
            //com as bibliotecas responsáver pelo reconhecimento e execução.
            else if(e.Contains("merlin abre o"))
            {
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (e == keywords[i])
                    {
                        string executar = "@/C" + string.Format("start {0}", @keywordscomands[i]);
                        Process.Start("CMD.exe", executar);
                        return;
                    }
                }
            }
        }
        //---------------------------------------------------------------------------------
        //Esconde a janela do console e deixa rodando em segundo plano até que rode o comando
        //de voz pra mostrar a janela novamente
        public void hide()
        {
            const int SW_HIDE = 0;
            var Handle = GetConsoleWindow();
            ShowWindow(Handle, SW_HIDE);
            return;
        }
        public void show()
        {
            const int SW_Show = 5;
            var Handle = GetConsoleWindow();
            ShowWindow(Handle, SW_Show);
            return;
        }
        //---------------------------------------------------------------------------------

    }
}

    

