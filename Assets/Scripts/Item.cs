using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Application = UnityEngine.Application;

public class Item : MonoBehaviour
{
    private const string TIME_CREATION = "Time since create: ";
    private const string FOLDER_PATH = "/Resources/";
    [SerializeField] private string[] m_textureExtensions;
    [SerializeField] private Text m_textName;
    [SerializeField] private Image m_image;
    [SerializeField] private Text m_timeSinceCreate;

    private string m_fullPath;
    private DateTime m_createTimeOfFile;
    public string NameItem => m_textName.text;
    public void SetItemPriporties(Sprite sprite)
    {
        string extensions = null;
        for (int i = 0; i < m_textureExtensions.Length; i++)
        {
            if (File.Exists(Application.dataPath + FOLDER_PATH + m_image.sprite.name + "." + m_textureExtensions[i]))
            {
                extensions = m_textureExtensions[i];
            }
        }
        m_image.sprite = sprite;
        m_textName.text = m_image.sprite.name;
        m_fullPath = Application.dataPath + FOLDER_PATH + m_image.sprite.name + "." + extensions;
        m_createTimeOfFile = File.GetCreationTime(m_fullPath);

        m_timeSinceCreate.text =TIME_CREATION + (DateTime.Now - m_createTimeOfFile).ToString();
    }

    public void RefreshDateTime()
    {
        m_timeSinceCreate.text =TIME_CREATION + (DateTime.Now - m_createTimeOfFile).ToString();
    }
}