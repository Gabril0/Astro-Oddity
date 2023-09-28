using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Custom/Player Data")]
public class PlayerData : ScriptableObject
{
    public float playerHealth;
    public float playerDamage;
    public float playerBulletCooldown;
    public float playerSpeed;
    public bool playerSlowDown;
    public float totalTime;
}
