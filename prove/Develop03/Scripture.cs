using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private string[] _wordStrings;
    private List<Word> _wordList;
    private string _metadata;
    private Random rnd = new Random();

    public Scripture()
    {
        //initializes class, splits up the scripture into individual word classes, and then makes a list of all the classes with the string
        Reference reference = new Reference(); 
        _wordStrings = reference.chosenVerse.Split(" ");
        _wordList = new List<Word>();
        _metadata = reference.metadata;
        foreach (string word in _wordStrings)
        {
            Word currentWord = new Word();
            currentWord.wordString = word;
            _wordList.Add(currentWord);
        }
    }

    public void DisplayScripture()
    {
        //displays scripture reference, then if the word is still valid, it writes it, otherwises it's blank
        Console.WriteLine(_metadata);
        foreach (Word word in _wordList)
        {
            if (word.exists)
            {
                Console.Write($"{word.wordString} ");
            }
            else
            {
                Console.Write("_____ ");
            }
        }
        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        for (int i = 0; i < 3; i++)
        {
            List<int> visibleWords = new List<int>();
            for (int j = 0; j < _wordList.Count; j++)
            {
                if (_wordList[j].exists)
                {
                    visibleWords.Add(j);
                }
            }
            
            if (visibleWords.Count > 0)
            {
                int randomVisible = visibleWords[rnd.Next(visibleWords.Count)];
                _wordList[randomVisible].exists = false;
            }
        }
    }

    public bool AllWordsHidden()
    {
        bool hidden = true;
        foreach (Word word in _wordList)
        {
            if (word.exists)
            {
                hidden = false;
            }
        }
        return hidden;
    }
}