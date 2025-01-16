using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;
using System.Text.RegularExpressions;

public class TextSplit : MonoBehaviour
{
    public string[] textChunks;

    public void Split(string longText)
    {
        //string[] words = longText.Split(' ');
        //int wordCount = words.Length;

        //// Split the long text into chunks of 10 words each
        //int wordsPerChunk = 15;
        //textChunks = new string[(wordCount + wordsPerChunk - 1) / wordsPerChunk];


        //for (int i = 0; i < textChunks.Length; i++)
        //{
        //    int start = i * wordsPerChunk;
        //    int length = Mathf.Min(wordsPerChunk, wordCount - start);
        //    string[] chunkWords = new string[length];
        //    Array.Copy(words, start, chunkWords, 0, length);
        //    textChunks[i] = string.Join(" ", chunkWords);
        //}

        string pattern = @"(\p{Lu}\.)\s+([A-Z])";
        string replacement = "$1$2";
        string updatedParagraph = Regex.Replace(longText, pattern, replacement);
        longText = updatedParagraph;

        string[] sentences = Regex.Split(longText, @"(?<=[.!?])\s+");

        textChunks = sentences;

        //// Split the long text into sentences
        //char[] sentenceDelimiters = new char[] {',','.', '!', '?', ';'};
        //string[] sentences = longText.Split(sentenceDelimiters, StringSplitOptions.RemoveEmptyEntries);

        //// Split any sentences longer than 30 words into chunks of 30 words each
        //int maxWordsPerSentence = 10;
        //List<string> processedSentences = new List<string>();
        //foreach (string sentence in sentences)
        //{
        //    string[] words = sentence.Trim().Split(' ');
        //    if (words.Length <= maxWordsPerSentence)
        //    {
        //        processedSentences.Add(sentence);
        //    }
        //    else
        //    {
        //        for (int i = 0; i < words.Length; i += maxWordsPerSentence)
        //        {
        //            int endIndex = Mathf.Min(i + maxWordsPerSentence, words.Length);
        //            string[] chunkWords = new string[endIndex - i];
        //            Array.Copy(words, i, chunkWords, 0, endIndex - i);
        //            string chunkSentence = string.Join(" ", chunkWords);
        //            processedSentences.Add(chunkSentence);
        //        }
        //    }
        //}

        //textChunks = processedSentences.ToArray();
    }
}
