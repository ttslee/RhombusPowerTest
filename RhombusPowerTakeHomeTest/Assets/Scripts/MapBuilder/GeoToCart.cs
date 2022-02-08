using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Math = System.Math;
 
 public class GeoToCart : MonoBehaviour
 {
 
     [SerializeField] Vector3 _worldSize = new Vector3(100,0,100);
     [SerializeField] Vector3 _worldOrigin = new Vector3(0,0,0);
 
    //  [SerializeField] bool _originFromPlayerPosition = false;
    //  [SerializeField] SightingInfo _playerPosition = new SightingInfo{ state="Player 0" , latitude=48.195932 , longitude=16.339999 };
 
    //  [SerializeField] float _worldPointSize = 1f;
    //  [SerializeField][Min(0.01f)] float _gizmoScale = 10f;
 
 
    // #if UNITY_EDITOR
    // // void OnValidate ()
    // // {
    // //     if( _originFromPlayerPosition )
    // //     {
    // //         UnityEditor.Undo.RecordObject( this , "Origin From Player Position" );
    // //         MoveOrigin( _playerPosition );
    // //     }
    // // }
    // void OnDrawGizmos ()
    // {
    //     if(MapBuilder.instance == null)
    //         return;
    //     Vector3 origin = transform.position;
        
    //     // draw sphere:
    //     Gizmos.color = new Color(0,1,1,.5f);
        
    //     Gizmos.DrawSphere( origin , _gizmoScale );
    //     Gizmos.DrawSphere( origin , _gizmoScale );

    //     // draw rect:
    //     Gizmos.color = Color.cyan;
    //     Vector2 rect = new Vector2( _gizmoScale*4f , _gizmoScale*2f );
    //     Vector3 rectCenterWorld = origin - Vector3.right*_gizmoScale*10f;
    //     Gizmos.DrawWireCube( rectCenterWorld , new Vector3(rect.x,rect.y,0) );

    //     // draw game world bounds:
    //     Gizmos.DrawWireCube( _worldOrigin , _worldSize );

    //     for( int i=MapBuilder.instance.sightingInfo.Length-1 ; i!=-1 ; i-- )
    //     {
    //         var coord = MapBuilder.instance.sightingInfo[i];

    //         // sphere:
    //         {
    //             Vector3 spherePoint = coord.ToVector3UnitSphere();
    //             Vector3 worlPos = origin + spherePoint*_gizmoScale;

    //             Gizmos.color = Color.yellow;
    //             Gizmos.DrawSphere( worlPos , _gizmoScale*0.01f );
    //             UnityEditor.Handles.Label( worlPos , coord.ToString() );
    //         }

    //         // rect:
    //         {
    //             Vector2 v2point = coord.ToVector2();
    //             Vector3 worlPos = rectCenterWorld + Vector3.Scale(v2point,rect*0.5f);

    //             Gizmos.color = Color.yellow;
    //             Gizmos.DrawSphere( worlPos , _gizmoScale*0.01f );
    //             UnityEditor.Handles.Label( worlPos , coord.ToString() );
    //         }

    //         // game world:
    //         {
    //             Vector3 v3point = coord.ToVector3();
    //             Vector3 worlPos = _worldOrigin + Vector3.Scale(v3point,_worldSize*0.5f);

    //             Gizmos.color = Color.green;
    //             Gizmos.DrawCube( worlPos , new Vector3(_worldPointSize,_worldPointSize,_worldPointSize) );
    //             UnityEditor.Handles.Label( worlPos , coord.ToString() );
    //         }
    //     }
    // }
    // #endif
    void MoveOrigin ( SightingInfo coord ) => _worldOrigin = -Vector3.Scale( coord.ToVector3() , _worldSize*0.5f );
 }
