// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.EventSystems;
//
// public class UIShortcutsController : MonoBehaviour, Observer {
//
//   private static float widthRatio = 0.75f;
//   private static float heightRatio = 0.75f;
//
//   static public void CreateUI() {
//     GameObject gameObject = new GameObject();
//     gameObject.name = "UIShortcutsCanvas";
//     gameObject.AddComponent<UIShortcutsController>();
//     gameObject.AddComponent<Canvas>();
//     gameObject.AddComponent<GraphicRaycaster>();
//
//     Canvas canvas = gameObject.GetComponent<Canvas>();
//     canvas.renderMode = RenderMode.ScreenSpaceOverlay;
//
//     GameObject backgroundImageGameObject = new GameObject();
//     backgroundImageGameObject.name = "UIShortcutsCanvas-backgroundImage";
//     backgroundImageGameObject.transform.SetParent(canvas.transform);
//     backgroundImageGameObject.AddComponent<UIShortcutsDragController>();
//
//     UIShortcutsDragController backgroundImageController = backgroundImageGameObject.GetComponent<UIShortcutsDragController>();
//     backgroundImageController.width = Screen.width * widthRatio;
//     backgroundImageController.height = Screen.height * heightRatio;
//
//     Image backgroundImage = backgroundImageGameObject.AddComponent<Image>();
//     backgroundImage.color = new Color(255, 255, 255);
//
//     GameObject scrollViewPrefab = (GameObject)Resources.Load("Prefabs/UI/ScrollView", typeof(GameObject));
//     GameObject scrollViewGameObject = Instantiate(scrollViewPrefab, new Vector3(0, 0, 0), Quaternion.identity, backgroundImageGameObject.transform);
//     scrollViewGameObject.transform.localPosition = new Vector2(0, 0);
//
//     RectTransform scrollViewRectTransform = scrollViewGameObject.GetComponent<RectTransform>();
//     scrollViewRectTransform.sizeDelta = new Vector2(backgroundImageController.width * 0.4f, backgroundImageController.height * 0.2f);
//
//     GameObject shortcutPrefab = (GameObject)Resources.Load("Prefabs/UI/Shortcut", typeof(GameObject));
//
//     RectTransform contentRectTransform = null;
//     Transform[] temp = scrollViewGameObject.GetComponentsInChildren<Transform>();
//
//     foreach (Transform Child in temp) {
//       if (Child.name == "Content") {
//         contentRectTransform = Child.gameObject.GetComponent<RectTransform>();
//       }
//     }
//
//     foreach (KeyValuePair<string, string> item in State._.shortcuts) {
//       GameObject shortcutGameObject = Instantiate(shortcutPrefab, new Vector3(0, 0, 0), Quaternion.identity, contentRectTransform);
//       shortcutGameObject.transform.localPosition = new Vector3(0, 0, 0);
//     }
//   }
//
//   void Start() {
//     gameObject.SetActive(State._.isUIShortcutsOpen._);
//     State._.isUIShortcutsOpen.Subscribe(this);
//   }
//
//   public void Update() {
//     if (gameObject.activeSelf != State._.isUIShortcutsOpen._) {
//       gameObject.SetActive(State._.isUIShortcutsOpen._);
//     }
//   }
//
// }
