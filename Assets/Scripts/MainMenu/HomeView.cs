using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Agate.MVC.Base;
using Agate.MVC.Core;


    public class HomeView : BaseSceneView
    {
        [SerializeField]
        private Button _playButton;

        public void SetCallBacks(UnityAction onClickplayButton)
        {
            _playButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(onClickplayButton);
        }
    }
