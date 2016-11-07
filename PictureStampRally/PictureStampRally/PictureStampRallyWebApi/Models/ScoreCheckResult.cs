﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace PictureStampRally.Models
{
    public partial class ScoreCheckResult
    {
        private int? _score;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Score
        {
            get { return this._score; }
            set { this._score = value; }
        }
        
        private int? _themeImageId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? ThemeImageId
        {
            get { return this._themeImageId; }
            set { this._themeImageId = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ScoreCheckResult class.
        /// </summary>
        public ScoreCheckResult()
        {
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken scoreValue = inputObject["Score"];
                if (scoreValue != null && scoreValue.Type != JTokenType.Null)
                {
                    this.Score = ((int)scoreValue);
                }
                JToken themeImageIdValue = inputObject["ThemeImageId"];
                if (themeImageIdValue != null && themeImageIdValue.Type != JTokenType.Null)
                {
                    this.ThemeImageId = ((int)themeImageIdValue);
                }
            }
        }
    }
}