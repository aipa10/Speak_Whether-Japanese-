using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicWand;

namespace Speak_Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                while (true)
                {
                    //パソコンからの質問
                    string instruction = "いつどこの天気を知りたいですか？";
                    Console.WriteLine(instruction);
                    Magic.Speak(instruction);

                    //音声で場所と日にちを指定
                    Console.Beep();
                    string voiceinput = Magic.Recognize();

                    //都市名と日にちを確認
                    string[] cityday = Magic.ExtractCityAndDay(voiceinput);

                    if (cityday[0] == "")
                    {
                        //やりなおし指示
                        Console.WriteLine("あなたの質問は「" + voiceinput + "」でした");
                        Magic.Speak("うまく聞き取れませんでした。都市と今日か明日の指定をはっきりお話ください。");
                        Console.WriteLine("");//空行
                        continue;
                    }
                    else
                    {
                        string kakunin = cityday[1] + "の" + cityday[0] + "の天気をお知らせします";
                        Console.WriteLine(kakunin);
                        Magic.Speak(kakunin);

                        //音声入力をもとに天気予報を表示
                        string weatherLine = Magic.GetWeatherLineByCity(cityday[0], cityday[1]);
                        Console.WriteLine(weatherLine);
                        Magic.Speak(weatherLine);
                        Console.WriteLine("");//空行
                    }

                }

            }
        }
    }
}
