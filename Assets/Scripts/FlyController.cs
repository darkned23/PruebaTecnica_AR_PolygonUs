using UnityEngine;
using System.Collections;

public class FlyController : MonoBehaviour
{
    [Header("Configuración")]
    public Animator animator;

    [Tooltip("Trigger que activa la animación de vuelo (fly)")]
    public string flyTrigger = "Fly";

    private bool isFlyingBoosted = false;
    private Coroutine boostCoroutine;
    private float boostElapsed = 0f;
    private float boostDuration = 0f;

    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    public void ActivateFlyBoost()
    {
        if (animator == null)
        {
            Debug.LogWarning("Animator no asignado.");
            return;
        }

        if (!isFlyingBoosted)
        {
            boostElapsed = 0f;
            boostDuration = 0f; // será inicializado en la corrutina
            boostCoroutine = StartCoroutine(FlyBoostCoroutine());
        }
    }

    private IEnumerator FlyBoostCoroutine()
    {
        isFlyingBoosted = true;

        // Activar el trigger para iniciar la animación de vuelo
        animator.ResetTrigger(flyTrigger);
        animator.SetTrigger(flyTrigger);

        // Esperar a que el Animator entre en el estado "fly"
        yield return null;

        // Obtener la duración del clip actual (la animación "fly")
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float flyDuration = stateInfo.length;
        if (boostDuration <= 0f) boostDuration = flyDuration;

        // Esperar hasta completar el tiempo restante, teniendo en cuenta pausas
        while (boostElapsed < boostDuration)
        {
            boostElapsed += Time.deltaTime;
            yield return null;
        }

        // Al terminar, el Animator vuelve solo a idle
        isFlyingBoosted = false;
        boostCoroutine = null;
    }

    void OnDisable()
    {
        // Si la corrutina está corriendo, la dejamos en pausa guardando elapsed
        if (boostCoroutine != null)
        {
            StopCoroutine(boostCoroutine);
            boostCoroutine = null;
            // isFlyingBoosted se mantiene true para indicar que había un boost en curso
            // No reseteamos isFlyingBoosted a false aquí; se restaurará cuando termine realmente
        }
    }

    void OnEnable()
    {
        // Si había un boost en curso (isFlyingBoosted true y boostElapsed < boostDuration), reanudar
        if (isFlyingBoosted && boostElapsed < boostDuration)
        {
            boostCoroutine = StartCoroutine(FlyBoostCoroutine());
        }
    }
}
