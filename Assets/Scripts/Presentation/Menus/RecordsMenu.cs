using UnityEngine;

public class RecordsMenu : MonoBehaviour
{
    public RectTransform VerticalLayout;
    public RectTransform RecordText;
    public RecordTableService RecordTableService;
    public GameObject Menu;
    private void OnEnable()
    {
        foreach (var item in RecordTableService.RecordTable.Records)
        {
            var text = Instantiate(RecordText, VerticalLayout);
            text.GetComponent<TMPro.TextMeshProUGUI>().text = $"{item.Score}";
        }
    }

    public void BackToMenu()
    {
        Menu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
