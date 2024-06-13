using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Object/Unit Data", order = int.MaxValue)]
public class UnitData : ScriptableObject
{
    // ���ֿ� �� ����
    // �̸�, ���, ����, ü��, ���ݷ�, ����, ������, ��ȭ �ܰ�
    
    [SerializeField] private string unitName;
    public string UnitName { get { return unitName; } }

    [SerializeField] private string unitRank;
    public string UnitRank { get { return unitRank; } }
    
    [SerializeField] private string unitType;
    public string UnitType { get { return unitType; } }
    
    [SerializeField] private float hp;
    public float HP { get { return hp; } }
    
    [SerializeField] private float power;
    public float Power { get { return power; } }
    
    [SerializeField] private float defense;
    public float Defense { get {  return defense; } }

    [SerializeField] private float buffRate;
    public float BuffRate { get {  return buffRate; } }

    [SerializeField] private int reinforce;
    public int Reinforce { get {  return reinforce; } }

    [SerializeField] private Image iconImage;
    public Image IconImage { get {  return iconImage; } }
}
