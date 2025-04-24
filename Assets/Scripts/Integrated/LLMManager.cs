using UnityEngine;
using System;
using LLMUnity;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;


public class LLMManager : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private LLMCharacter llmCharacter;
    [SerializeField] private Transcript transcript;
    [SerializeField] private Avatar avatar;
    public event Action OnStartTTS;
    public event Action OnSentenceTTS;

    // [SerializeField] private LLMCharacter[] customers;

    void Start()
    {   

        // int randomNum = UnityEngine.Random.Range(0, customers.Length);

        // llmCharacter = customers[randomNum];

        if (llmCharacter == null || transcript == null)
        {
            Debug.LogWarning("Missing components in LLMManager");
            return;
        }

        transcript.OnNewPlayerResponse += HandleNewPlayerResponse;
        
    }

    private void HandleNewPlayerResponse(string message)
    {
        if (!string.IsNullOrEmpty(message))
        {
            Debug.Log("You Said: " + alToString(targetWord(message)));

            // Send message to LLM
            transcript.latestAvatarResponse = "";
            _ = llmCharacter.Chat(message, HandleReply, ReplyCompleted);
        }
    }

    // Avatar Response Handlers
    void HandleReply(string reply)
    {
        transcript.latestAvatarResponse = reply;
        Debug.Log("REPLY: " + reply);

    }

    void ReplyCompleted()
    {
        Debug.Log("Avatar Said: " + alToString(targetWord(transcript.latestAvatarResponse)));


        // Extract Actions from text
        transcript.latestAvatarResponse = extractActions(transcript.latestAvatarResponse);

        OnStartTTS?.Invoke();

        // Separate avatar response into sentences
        string[] sentences = Regex.Split(transcript.latestAvatarResponse, @"(?<=[.!?])\s+");

        StartCoroutine(ProcessSentencesForTTS(sentences));
    }

    static ArrayList targetWord(string message){
      string[] menu = {"hotdog", "hot dog", "taco"};
      ArrayList saidFood = new ArrayList();
        
        if(menu.Any(message.Contains)){
            foreach (string food in menu){
                if (message.Contains(food)){
                    saidFood.Add(food);
                }
            }
            // printArrLst(saidFood);
            return saidFood;
        }
        
        return null;
    }

    static void printArrLst(ArrayList arr){
      foreach (string food in arr){
          Debug.Log(food);
      }
    }

    static string alToString(ArrayList arr){
      string str = "";
      
      if (arr != null){
        foreach (string food in arr){
          str += ", " + food;
        }
        
        return "[" + str.Substring(2) + "]";
      }
      return "NULL";
      
    }
    

    private IEnumerator ProcessSentencesForTTS(string[] sentences)
    {
        foreach (string sentence in sentences)
        {
            if (!string.IsNullOrWhiteSpace(sentence))
            {
                Debug.Log("Processing sentence in TTS: " + sentence);

                transcript.latestAvatarResponse = sentence;
                dialogueManager.TextToSpeech();
                OnSentenceTTS?.Invoke();
                
                yield return StartCoroutine(dialogueManager.WaitForAvatarAudioToFinish());
            }
        }
    }

    private string extractActions(string text)
    {
        List<string> actions = new List<string>();

        // Regex to find actions in parantheses. i.e. "(smile)"
        Regex regex = new Regex(@"\((.*?)\)");
        MatchCollection matches = regex.Matches(text);

        // Add each action to the actions list
        foreach (Match match in matches)
        {
            string action = match.Groups[1].Value;

            // Queue action for AvatarController
        }
        // Remove actions in parantheses from original text
        text = regex.Replace(text, "").Trim();
        return text;
    }
}
