using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSoundEffect", menuName = "Audio/New Sound Effect")]
public class SoundEffectSo : ScriptableObject
{

   #region config

   public AudioClip[] clips;
   public Vector2 volume = new Vector2(0.5f, 0.5f);
   public Vector2 pitch = new Vector2(1, 1);
   [SerializeField] private SoundClipPlayOrder playOrder;
   
   [HideIfEnumValue("playOrder",HideIf.NotEqual, (int) SoundClipPlayOrder.pickone)]
   [SerializeField] private int soundIndex = 0;
   #endregion
   private int playIndex = 0;

   private AudioClip GetAudioClip()
   {
      // get current clip
      var clip = clips[playIndex >= clips.Length ? 0 : playIndex];

      // find next clip
      switch (playOrder)
      {
         case SoundClipPlayOrder.in_order:
            playIndex = (playIndex + 1) % clips.Length;
            break;
         case SoundClipPlayOrder.random:
            playIndex = Random.Range(0, clips.Length);
            break;
         case SoundClipPlayOrder.reverse:
            playIndex = (playIndex + clips.Length - 1) % clips.Length;
            break;
         case SoundClipPlayOrder.pickone:
            playIndex = soundIndex; 
            break;
      }

      // return clip
      return clip;
   }
   
   public AudioSource Play(AudioSource audioSourceParam = null)
   {
      if (clips.Length == 0)
      {
         Debug.LogWarning("Missing sound clips");
         return null;
      }

      var source = audioSourceParam;
      if (source == null)
      {
         var obj = new GameObject("Sound", typeof(AudioSource));
         source = obj.GetComponent<AudioSource>();
      }
      
      //set source config
      if (playOrder == SoundClipPlayOrder.pickone && soundIndex >= clips.Length)
      {
         Debug.LogWarning("sound index out of bounds!!");
         return null;
      }
      source.clip = GetAudioClip();
      source.volume = Random.Range(volume.x, volume.y);
      source.pitch = Random.Range(pitch.x, pitch.y);
      source.Play();
      Destroy(source.gameObject, source.clip.length / source.pitch);

      return source;

   }
   enum SoundClipPlayOrder
   {
      random,
      in_order,
      reverse,
      pickone
   }
}
