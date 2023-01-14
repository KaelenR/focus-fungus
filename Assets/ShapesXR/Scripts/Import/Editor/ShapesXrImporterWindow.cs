using ShapesXr.Import.Core;
using UnityEditor;
using UnityEngine;

namespace ShapesXr
{
    public class ShapesXrImporterWindow : EditorWindow
    {
        private static Texture2D _logo;

        private static bool _showSettings;

        private static SerializedObject _importSettingsObject;
        
        private static SerializedProperty _accessCodeProperty;
        private static SerializedProperty _materialMapperProperty;
        private static SerializedProperty _importedDataDirectoryProperty;
        private static SerializedProperty _materialModeProperty;

        public static string ErrorMessage { get; set; } = "";

        [MenuItem("ShapesXR/Importer")]
        public static void ShowWindow()
        {
            GetWindow<ShapesXrImporterWindow>(false, "ShapesXR Importer", true);
        }

        private void OnEnable()
        {
            _importSettingsObject = new SerializedObject(ImportSettings.Instance);
            
            _accessCodeProperty = _importSettingsObject.FindProperty("_accessCode");
            
            _importedDataDirectoryProperty = _importSettingsObject.FindProperty("_importedDataDirectory");
            _materialMapperProperty = _importSettingsObject.FindProperty("_materialMapper");
            _materialModeProperty = _importSettingsObject.FindProperty("_materialMode");

            ImportSettingsProvider.ImportSettings = ImportSettings.Instance;
        }

        private void OnGUI()
        {
            _importSettingsObject.Update();

            EditorGUILayout.BeginVertical();

            DrawLogo();

            if (!ErrorMessage.IsNullOrEmpty())
            {
                EditorGUILayout.HelpBox(ErrorMessage, MessageType.Error);
            }

            EditorGUILayout.BeginHorizontal();

            string accessCode = GUILayout.TextField(_accessCodeProperty.stringValue);

            _accessCodeProperty.stringValue = accessCode;

            if (GUILayout.Button("Import Space"))
            {
                ErrorMessage = "";
                
                _importSettingsObject.ApplyModifiedProperties();
                
                var trimmedCode = accessCode.Trim().Replace(" ", "");

                if (string.IsNullOrEmpty(trimmedCode))
                {
                    if(ImportSettings.SendAnalytics)
                    {
                        Analytics.SendEvent(EventStatus.incorrect_code_signature);
                    }

                    ErrorMessage = "You haven't entered a code. Enter the code to import space";
                    
                    Debug.LogError(ErrorMessage);
                }
                else
                {
                    SpaceImporter.ImportSpace(accessCode.Replace(" ", "").ToLower()); 
                }
            }

            EditorGUILayout.EndHorizontal();

            _showSettings = EditorGUILayout.Foldout(_showSettings, "Settings", EditorStyles.foldoutHeader);

            if (!_showSettings)
            {
                EditorGUILayout.EndVertical();
                _importSettingsObject.ApplyModifiedProperties();
                
                return;
            }

            EditorGUILayout.Space();
            
            EditorGUILayout.LabelField("General", EditorStyles.boldLabel);
            
            EditorGUILayout.PropertyField(_importedDataDirectoryProperty);
            EditorGUILayout.Space();
            
            EditorGUILayout.LabelField("Material", EditorStyles.boldLabel);
            
            EditorGUILayout.PropertyField(_materialModeProperty,new GUIContent("Import Mode"));
            EditorGUILayout.PropertyField(_materialMapperProperty,new GUIContent("Mapper"));

            var rawString = _importedDataDirectoryProperty.stringValue;
            _importedDataDirectoryProperty.stringValue = rawString.Trim(' ', '\\', '/');
            
            _importSettingsObject.ApplyModifiedProperties();

            EditorGUILayout.EndVertical();
        }

        private void DrawLogo()
        {
            EditorGUILayout.BeginHorizontal();
            
            GUILayout.FlexibleSpace();
            GUILayout.Label(ImportResources.ShapesXrLogo);
            GUILayout.FlexibleSpace();
            
            EditorGUILayout.EndHorizontal();
        }
    }
}