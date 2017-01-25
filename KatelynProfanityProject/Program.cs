using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KatelynProfanityProject
{
    class Program
    {

        //v1
        //You're an asshole. 0
        //You are stupid. 2
        //You suck. 1
        //You suck balls 1
        //You'sa a bitch ass hoe. 0

        //v2 lol
        //Your mother sucks. 1
        //Your mother is a bitch ass hoe. 0

        static void Main(string[] args)
        {
            Random rnd = new Random();

            XDocument sentenceXml =
                    XDocument.Load(@"sentenceStructures.xml");

            //Parse words into arrays

            List<string[]> subjects = new List<string[]>();
            subjects.Add(sentenceXml.Descendants("subjectnoun").Select(element => element.Value).ToArray());
            subjects.Add(sentenceXml.Descendants("subjectverbnoun").Select(element => element.Value).ToArray());
            subjects.Add(sentenceXml.Descendants("subjectadjective").Select(element => element.Value).ToArray());

            string[] nouns = sentenceXml.Descendants("noun").Select(element => element.Value).ToArray();
            string[] verbs = sentenceXml.Descendants("verb").Select(element => element.Value).ToArray();
            string[] adjectives = sentenceXml.Descendants("adjective").Select(element => element.Value).ToArray();

            for (int i = 0; i < 100; i++)
            {
                var insult = "";

                //Pick an insult type. 3 types 0 1 2.
                //0 Subject - Noun
                //1 Subject - Verb - (Noun)
                //2 Subject - Adjective

                //2 is cancelled until we get better words.
                var insultType = rnd.Next(2);

                //Build Subject
                insult += subjects[insultType][rnd.Next(subjects[insultType].Length)];
                string noun =  (rnd.Next(3) == 0 ? " " + adjectives[rnd.Next(adjectives.Length)] : "") + " " + nouns[rnd.Next(nouns.Length)];

                //Build rest of sentence, lol
                switch (insultType)
                {
                    case 0: //Subject - Noun
                        insult += ("aeiou".Contains(Char.ToLower(noun[1])) ? "n" : "") + noun; //shit some y')s will be weird?
                        break;
                    case 1: //Subject - Verb - (Noun)
                        insult += " " + verbs[rnd.Next(verbs.Length)] + (rnd.Next(3) > 0 ? noun + "s" : ""); //plurals are going to suck :(. y. weird words.
                        break;
                    case 2: //Subject - Adjective
                        insult += " " + adjectives[rnd.Next(adjectives.Length)];
                        break;
                }

                //HILARIOUS BONUSES

                //print that shit.
                Console.WriteLine(insult);
                Console.ReadLine();
            }
        }
    }
}


//You're an asshole.
//- subject noun
//You are stupid.
//-subject adjective
//You suck.
//- subject verb
//You suck balls
//-subject verb noun
//You'sa a bitch ass hoe.
//- subject adjective - noun
//Your mother sucks.
//- possesive noun? verb
//Your mother is a bitch ass hoe.
//- possessive noun? adjective-noun

//subject noun adjective verb +HILARIOUSEXTRAS

//You VERB NOUN
//You'sa NOUN
//You're a(n) NOUN
//You are a(n) NOUN
//Your NOUN

//SUBJECT NOUN
//SUBJECT VERB NOUN
//SUBJECT ADJECTIVE
//
//
//

//Tree?

//Noun = NOUN, ADJECTIVE-NOUN
//Subject = You