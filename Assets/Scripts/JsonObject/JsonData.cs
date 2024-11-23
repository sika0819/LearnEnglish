using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine;
namespace Sika.JsonObject
{
    [Serializable]
    public class Audio
    {
        [SerializeField]
        public string id;
        [SerializeField]
        public string url;
        [SerializeField]
        public int size;
        [SerializeField]
        public string sha1;
        [SerializeField]
        public string mimeType;
        [SerializeField]
        public int width;
        [SerializeField]
        public int height;
        [SerializeField]
        public string language;
        [SerializeField]
        public string title;
        [SerializeField]
        public int duration;
        [SerializeField]
        public string thumbnails;
    }

    [Serializable]
    public class Body
    {
        [SerializeField]
        public Item item;
        [SerializeField]
        public string version;
        [SerializeField]
        public List<TagsItem> tags;
        [SerializeField]
        public string skillSet;
        [SerializeField]
        public List<string> tests;
        [SerializeField]
        public List<OptionsItem> options;
        [SerializeField]
        public string layoutMode;
        [SerializeField]
        public List<List<int>> answers;
        [SerializeField]
        public string mode;
        [SerializeField]
        public string background;
        [SerializeField]
        public string asrEngine;
        [SerializeField]
        public int hintTime;
    }
    [Serializable]
    public class StimulusItem
    {
        [SerializeField]
        public string Key;
        [SerializeField]
        public Body Body;
        [SerializeField]
        public string Tags;
        [SerializeField]
        public string Type;
        [SerializeField]
        public string stimulusOfQuestion;
        [SerializeField]
        public float questionAnchor;
        [SerializeField]
        public float answerAnchor;
        [SerializeField]
        public bool isForModeling;
    }
    [Serializable]
    public class TagsItem
    {
        [SerializeField]
        public string compassTags;
        [SerializeField]
        public string subSkillSet;
        [SerializeField]
        public string vocabulary;
        [SerializeField]
        public int rows;
        [SerializeField]
        public int cols;
        [SerializeField]
        public string primary_skill_set;
    }
    [Serializable]
    public class Image
    {
        [SerializeField]
        public string id;
        [SerializeField]
        public string url;
        [SerializeField]
        public int size;
        [SerializeField]
        public string sha1;
        [SerializeField]
        public string mimeType;
        [SerializeField]
        public int width;
        [SerializeField]
        public int height;
        [SerializeField]
        public string language;
        [SerializeField]
        public string title;
        [SerializeField]
        public int duration;
        [SerializeField]
        public string thumbnails;
    }
    [Serializable]
    public class OptionsItem
    {
        [SerializeField]
        public string type;
        [SerializeField]
        public string id;
        [SerializeField]
        public string text;
        [SerializeField]
        public string prompt;
        [SerializeField]
        public string hideText;
        [SerializeField]
        public Image image;
        [SerializeField]
        public string audio;
        [SerializeField]
        public string pdf;
        [SerializeField]
        public string video;
        [SerializeField]
        public string audioLocal;
        [SerializeField]
        public string academic;
        [SerializeField]
        public string showMode;
        [SerializeField]
        public string subtitles;
        [SerializeField]
        public int rowIndex;
        [SerializeField]
        public int colIndex;
        [SerializeField]
        public string lockedPosition;
        [SerializeField]
        public string expected;
        [SerializeField]
        public string speaker;
        [SerializeField]
        public string table;
        [SerializeField]
        public int startRow;
        [SerializeField]
        public int endRow;
        [SerializeField]
        public int startCol;
        [SerializeField]
        public int endCol;
        [SerializeField]
        public string cells;
    }
    [Serializable]
    public class Item
    {
        [SerializeField]
        public string type;
        [SerializeField]
        public string id;
        [SerializeField]
        public string text;
        [SerializeField]
        public string prompt;
        [SerializeField]
        public string hideText;
        [SerializeField]
        public string image;
        [SerializeField]
        public Audio audio;
        [SerializeField]
        public string pdf;
        [SerializeField]
        public string video;
        [SerializeField]
        public string audioLocal;
        [SerializeField]
        public string academic;
        [SerializeField]
        public string showMode;
        [SerializeField]
        public string subtitles;
        [SerializeField]
        public int rowIndex;
        [SerializeField]
        public int colIndex;
        [SerializeField]
        public string lockedPosition;
        [SerializeField]
        public string expected;
        [SerializeField]
        public string speaker;
        [SerializeField]
        public string table;
        [SerializeField]
        public int startRow;
        [SerializeField]
        public int endRow;
        [SerializeField]
        public int startCol;
        [SerializeField]
        public int endCol;
        [SerializeField]
        public string cells;
    }

    [Serializable]
    public class StimulusOfQuestion
    {
        [SerializeField]
        public string Key;
        [SerializeField]
        public Body Body;
        [SerializeField]
        public string Tags;
        [SerializeField]
        public string Type;
        [SerializeField]
        public string stimulusOfQuestion;
        [SerializeField]
        public float questionAnchor;
        [SerializeField]
        public float answerAnchor;
        [SerializeField]
        public bool isForModeling;
    }
    [Serializable]
    public class QuestionsItem
    {
        [SerializeField]
        public string Key;
        [SerializeField]
        public Body Body;
        [SerializeField]
        public string Tags;
        [SerializeField]
        public string Type;
        [SerializeField]
        public StimulusOfQuestion stimulusOfQuestion;
        [SerializeField]
        public float questionAnchor;
        [SerializeField]
        public float answerAnchor;
        [SerializeField]
        public bool isForModeling;
    }
    [Serializable]
    public class MappingsItem
    {
        [SerializeField]
        public string s;
        [SerializeField]
        public string q;
        [SerializeField]
        public string anchor;
    }
    [Serializable]
    public class Tags
    {
        [SerializeField]
        public List<string> primary_skill_set;
        [SerializeField]
        public string skillType;
    }
    [Serializable]
    public class ActivityBody
    {
        [SerializeField]
        public List<MappingsItem> mappings;
        [SerializeField]
        public Tags tags;
    }
    [Serializable]
    public class ActivityInfo
    {
        [SerializeField]
        public List<StimulusItem> Stimulus;
        [SerializeField]
        public List<QuestionsItem> Questions;
        [SerializeField]
        public string Title;
        [SerializeField]
        public string Key;
        [SerializeField]
        public ActivityBody Body;
        [SerializeField]
        public string Tags;
        [SerializeField]
        public string Type;
        [SerializeField]
        public string activityQuestionMd5;
        [SerializeField]
        public string part;
        [SerializeField]
        public string ContentId;
        [SerializeField]
        public string ContentRevision;
    }
    [Serializable]
    public class ProductInfo
    {
        [SerializeField]
        public string ProductName;
        [SerializeField]
        public string BookName;
        [SerializeField]
        public string UnitName;
        [SerializeField]
        public string LessonName;
        [SerializeField]
        public ActivityInfo Activity;
        [SerializeField]
        public string Owner;
        [SerializeField]
        public string Key;
        [SerializeField]
        public string CreatedStamp;
        [SerializeField]
        public string LastUpdatedStamp;
        [SerializeField]
        public int State;
    }
}