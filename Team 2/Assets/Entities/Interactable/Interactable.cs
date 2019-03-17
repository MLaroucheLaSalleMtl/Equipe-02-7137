using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 17 MARS 2019
/// @description Abstract design of anything that is interactable in the world
/// </summary>
public class Interactable : MonoBehaviour
{

    //How close the player has to be to interact with it
    public float actionRadius = 3f;

    /// <summary>
    /// Execute the action of the interactable
    /// </summary>
    /// <param name="player"></param>
    protected virtual void ExecuteAction(Player player)
    {
        Debug.LogWarning("Abstract interactable action called. Supposed to be overwritten.");
    }

    /// <summary>
    /// When the player interact with the object
    /// </summary>
    public void OnInteract (Player player)
    {
        float distance = Vector3.Distance(player.WorldModel.transform.position, transform.position);
        if (distance <= actionRadius)
        {
            ExecuteAction(player);
        }
    }

    /// <summary>
    /// Draws a gizmo in unity to visualize the action radius of the object
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        //gizmo in the editor is gonna be yellow
        Gizmos.color = Color.yellow;
        //draw a sphere gizmo at our position with the action radius
        Gizmos.DrawWireSphere(transform.position, actionRadius);
    }

}