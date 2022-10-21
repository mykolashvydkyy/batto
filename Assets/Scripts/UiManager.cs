using UnityEngine;
using UnityEngine.UIElements;

public class UiManager : MonoBehaviour
{
    [SerializeField] private UIDocument entryUi;
    [SerializeField] private UIDocument gamePlayUi;
    [SerializeField] private UIDocument gameOverUi;
    [SerializeField] private UIDocument winUi;

    public UIDocument EntryUi => entryUi; 
    public UIDocument GamePlayUi => gamePlayUi; 
    public UIDocument GameOverUi => gameOverUi;
    public UIDocument WinUi => winUi;

    public static UiManager instance;

    private void Awake()
    {
        if (instance is null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        entryUi.rootVisualElement.visible = false;
        gamePlayUi.rootVisualElement.visible = false;
        gameOverUi.rootVisualElement.visible = false;
        WinUi.rootVisualElement.visible = false;
    }

    public void SetWinData()
    {
        winUi.GetComponentInParent<WinUiController>().SetData();
    }

    public void SetLoosedata()
    {
        gameOverUi.GetComponentInParent<WinUiController>().SetData();
    }
}
