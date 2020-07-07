using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace VirtualTour.UIG
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject MenuPanel;
        public GameObject AboutStationPanel;

        public GameObject ManagementPanel;
        public GameObject TooltipPanel;
        public GameObject Aim;
        public GameObject FPC;
        public GameObject AnimationCamera;

        public GameObject AssignationInfoPanel;
        public GameObject StationStaffInfoPanel;
        public GameObject TTCStationInfoPanel;
        public GameObject SafetyReqsInfoPanel;
        public GameObject DeploymentInfoPanel;

        public GameObject AboutDevInfoPanel;

        public List<GameObject> BackgroundMenuPanels;

        private static int gamesAmountCounter;

        private static bool isScenesEnded;

        private static string FIRST_SCENE_NAME = "Disposition";

        private AudioSource _menuAudio;
        private Image _background;

        private bool isManagementRun;
        private bool isOnGame;

        public void Awake()
        {
            _menuAudio = GetComponent<AudioSource>();
            _background = GetComponent<Image>();
            CollapseAllLeaveStartMenu();
            FPC.SetActive(false);
            AnimationCamera.SetActive(true);
            gamesAmountCounter++;

            if (isScenesEnded)
            {
                StartGame();
            }
        }

        public void Update()
        {
            RunEscapeKey();
            RunF1Key();
        }

        public void CollapseAllLeaveStartMenu()
        {
            AboutStationPanel.SetActive(false);
            ManagementPanel.SetActive(false);
            TooltipPanel.SetActive(false);

            AssignationInfoPanel.SetActive(false);
            StationStaffInfoPanel.SetActive(false);
            TTCStationInfoPanel.SetActive(false);
            SafetyReqsInfoPanel.SetActive(false);
            DeploymentInfoPanel.SetActive(false);
            AboutDevInfoPanel.SetActive(false);

            MenuPanel.SetActive(true);
        }

        public void RunEscapeKey()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (MenuPanel.activeSelf)
                {
                    ExitApplication();
                }
                else
                {
                    StopGame();
                    ManagementPanel.SetActive(false);
                    TooltipPanel.SetActive(false);
                }
            }
        }

        public void RunF1Key()
        {
            if (Input.GetKeyUp(KeyCode.F1))
            {
                if (isOnGame)
                {
                    if (isManagementRun)
                    {
                        ManagementPanel.SetActive(false);
                        TooltipPanel.SetActive(true);
                    }
                    else
                    {
                        ManagementPanel.SetActive(true);
                        TooltipPanel.SetActive(false);
                    }

                    isManagementRun = !isManagementRun;
                }
            }
        }

        public void StartGameFromScenes()
        {
            if (gamesAmountCounter > 1)
            {
                StartGame();
            }
            else
            {
                isScenesEnded = true;
                SceneManager.LoadScene(FIRST_SCENE_NAME);
            }    
        }

        public void StartGame()
        {
            SetActiveBackground(false);
            MenuPanel.SetActive(false);

            AboutStationPanel.SetActive(false);
            AssignationInfoPanel.SetActive(false);
            StationStaffInfoPanel.SetActive(false);
            TTCStationInfoPanel.SetActive(false);
            SafetyReqsInfoPanel.SetActive(false);
            DeploymentInfoPanel.SetActive(false);
            AboutDevInfoPanel.SetActive(false);

            AnimationCamera.SetActive(false);
            FPC.SetActive(true);
            TooltipPanel.SetActive(true);
            isOnGame = true;
            _menuAudio.enabled = false;
        }

        public void StopGame()
        {
            MenuPanel.SetActive(true);
            SetActiveBackground(true);

            AboutStationPanel.SetActive(false);
            AssignationInfoPanel.SetActive(false);
            StationStaffInfoPanel.SetActive(false);
            TTCStationInfoPanel.SetActive(false);
            SafetyReqsInfoPanel.SetActive(false);
            DeploymentInfoPanel.SetActive(false);
            AboutDevInfoPanel.SetActive(false);

            AnimationCamera.SetActive(true);
            FPC.SetActive(false);
            TooltipPanel.SetActive(false);
            isOnGame = false;
            _menuAudio.enabled = true;
        }

        public void ExitApplication()
        {
            Application.Quit();
        }

        public void GoToAboutStationPanel()
        {
            if (AboutStationPanel.activeSelf)
            {
                AboutStationPanel.SetActive(false);
            }
            else
            {
                AboutStationPanel.SetActive(true);
            }
        }

        public void GoToAssignationInfo()
        {
            if (AssignationInfoPanel.activeSelf)
            {
                AssignationInfoPanel.SetActive(false);
                AboutStationPanel.SetActive(true);
                MenuPanel.SetActive(true);
                foreach (var item in BackgroundMenuPanels)
                {
                    item.SetActive(true);
                }
            }
            else
            {
                MenuPanel.SetActive(false);
                AboutStationPanel.SetActive(false);
                foreach (var item in BackgroundMenuPanels)
                {
                    item.SetActive(false);
                }

                AssignationInfoPanel.SetActive(true);
            }
        }

        public void GoToStationStaffInfo()
        {
            if (StationStaffInfoPanel.activeSelf)
            {
                StationStaffInfoPanel.SetActive(false);
                AboutStationPanel.SetActive(true);
                MenuPanel.SetActive(true);
                foreach (var item in BackgroundMenuPanels)
                {
                    item.SetActive(true);
                }
            }
            else
            {
                MenuPanel.SetActive(false);
                AboutStationPanel.SetActive(false);
                foreach (var item in BackgroundMenuPanels)
                {
                    item.SetActive(false);
                }

                StationStaffInfoPanel.SetActive(true);
            }
        }

        public void GoToTTCStationInfo()
        {
            if (TTCStationInfoPanel.activeSelf)
            {
                TTCStationInfoPanel.SetActive(false);
                AboutStationPanel.SetActive(true);
                MenuPanel.SetActive(true);
                foreach (var item in BackgroundMenuPanels)
                {
                    item.SetActive(true);
                }
            }
            else
            {
                MenuPanel.SetActive(false);
                AboutStationPanel.SetActive(false);
                foreach (var item in BackgroundMenuPanels)
                {
                    item.SetActive(false);
                }

                TTCStationInfoPanel.SetActive(true);
            }
        }

        public void GoToSafetyReqsInfo()
        {
            if (SafetyReqsInfoPanel.activeSelf)
            {
                SafetyReqsInfoPanel.SetActive(false);
                AboutStationPanel.SetActive(true);
                MenuPanel.SetActive(true);
                foreach (var item in BackgroundMenuPanels)
                {
                    item.SetActive(true);
                }
            }
            else
            {
                MenuPanel.SetActive(false);
                AboutStationPanel.SetActive(false);
                foreach (var item in BackgroundMenuPanels)
                {
                    item.SetActive(false);
                }

                SafetyReqsInfoPanel.SetActive(true);
            }
        }

        public void GoToDeploymentInfo()
        {
            if (DeploymentInfoPanel.activeSelf)
            {
                DeploymentInfoPanel.SetActive(false);
                AboutStationPanel.SetActive(true);
                MenuPanel.SetActive(true);
                foreach (var item in BackgroundMenuPanels)
                {
                    item.SetActive(true);
                }
            }
            else
            {
                MenuPanel.SetActive(false);
                AboutStationPanel.SetActive(false);
                foreach (var item in BackgroundMenuPanels)
                {
                    item.SetActive(false);
                }

                DeploymentInfoPanel.SetActive(true);
            }
        }

        public void GoToDevInfo()
        {
            if (AboutDevInfoPanel.activeSelf)
            {
                AboutDevInfoPanel.SetActive(false);
                MenuPanel.SetActive(true);
                foreach (var item in BackgroundMenuPanels)
                {
                    item.SetActive(true);
                }
            }
            else
            {
                MenuPanel.SetActive(false);
                AboutStationPanel.SetActive(false);
                foreach (var item in BackgroundMenuPanels)
                {
                    item.SetActive(false);
                }

                AboutDevInfoPanel.SetActive(true);
            }
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        private void SetActiveBackground(bool value)
        {

            if (value)
            {
                _background.enabled = true;
                foreach (var item in BackgroundMenuPanels)
                {
                    item.SetActive(true);
                }

                Aim.SetActive(false);
            }
            else
            {
                _background.enabled = false;
                foreach (var item in BackgroundMenuPanels)
                {
                    item.SetActive(false);
                }

                Aim.SetActive(true);
            }
        }
    }
}