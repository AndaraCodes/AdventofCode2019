﻿using System;
using System.Drawing;
using System.Collections.Generic;

namespace AdventofCode2019
{
    class GenerateAnswers
    {
        internal int GenerateAnswerDayTwo(List<int> inputList)
        {
            int noun = 0;
            int verb = 0;
            int counter = 0;

            while (true)
            {
                List<int> answerList = new List<int>(inputList);
                answerList[1] = noun;
                answerList[2] = verb;
                int index = 0;

                while (true)
                {
                    int tempVal = 0;
                    if (answerList[index] == 99) { break; }
                    if (answerList[index] == 1)
                    {
                        ++index;
                        tempVal = answerList[answerList[index]];
                        ++index;
                        tempVal += answerList[answerList[index]];
                        ++index;
                        answerList[answerList[index]] = tempVal;
                        ++index;
                    }
                    else
                    {
                        ++index;
                        tempVal = answerList[answerList[index]];
                        ++index;
                        tempVal *= answerList[answerList[index]];
                        ++index;
                        answerList[answerList[index]] = tempVal;
                        ++index;
                    }
                }

                Console.WriteLine(counter);
                counter++;

                if (answerList[0] == 19690720) { break; }
                if (noun < 100)
                {
                    ++noun;
                }
                else
                {
                    noun = 0;
                    ++verb;
                }
            }

            return noun * 100 + verb;
        }

        internal int GenerateAnswerDayThree(List<Point> one, List<Point> two)
        {
            List<Point> crossings = new List<Point>();

            foreach(Point pointOne in one)
            {
                foreach(Point pointTwo in two)
                {
                    if (pointOne.Equals(pointTwo))
                    {
                        crossings.Add(new Point((Size)pointOne));
                    }
                }
            }

            int answer = Int32.MaxValue;
            foreach(Point crossing in crossings)
            {
                int x = crossing.X;
                if (x < 0) { x *= -1; }
                int y = crossing.Y;
                if (y < 0) { y *= -1; }

                if (x + y < answer)
                {
                    answer = x + y;
                }
            }

            return answer;
        }
    }
}
