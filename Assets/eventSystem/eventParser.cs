using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace rm2.eventSystem
{
    public static class eventParser
    {
        public static eventClass[] parseEvent(string input)
        {
            string[] lines = input.Split('\n');
            string[][] words = lines.Select(x => x.Split(' ')).ToArray();
            List<eventClass> result = new List<eventClass>();
            for (int i = 0; i < lines.Length; i++)
            {
                string[] currentLine = words[i];
                string actor = currentLine[0];

                if (actor.Contains("{"))
                {
                    Debug.Log("Block detected in line " + i);
                    int currentIndex = i + 1;
                    while (!words[currentIndex][0].Contains("}"))
                    {
                        if (words[currentIndex][0].Contains("{"))
                        {
                            currentIndex = ignoreOtherStep(words, currentIndex + 1);
                        }
                        currentIndex++;
                    }
                    string blockInput = string.Join(
                            "\n",
                            lines.Skip(i + 1).Take(currentIndex - i - 1)
                        )
                        .Replace("\t", "");
                    Debug.Log(blockInput);
                    string[] actorArgs = new string[currentLine.Length - 1];
                    for (int j = 1; j < currentLine.Length; j++)
                    {
                        actorArgs[j - 1] = currentLine[j].Replace("\"", "");
                    }
                    result.Add(new eventClass(actorArgs, parseEvent(blockInput)));
                    i = currentIndex;
                }
                else
                {
                    string[] actorArgs = new string[currentLine.Length - 1];
                    for (int j = 1; j < currentLine.Length; j++)
                    {
                        actorArgs[j - 1] = currentLine[j].Replace("\"", "");
                    }
                    result.Add(new eventClass(eventActorFactory.str2EA(actor), actorArgs));
                }
            }

            return result.ToArray();
        }

        public static int ignoreOtherStep(string[][] words, int currentIndex)
        {
            while (!words[currentIndex][0].Contains("}"))
            {
                if (words[currentIndex][0].Contains("{"))
                {
                    currentIndex = ignoreOtherStep(words, currentIndex + 1);
                }
                currentIndex++;
            }
            return currentIndex;
        }
    }
}
