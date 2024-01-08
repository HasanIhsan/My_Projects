document.addEventListener("DOMContentLoaded", function() {
    const walkingDog = document.getElementById("walkingDog");

    if (walkingDog) {
        walkingDog.classList.add("walkingAnimation");
    }

    walkingDog.addEventListener("click", function() {
        const currentPosition = getComputedStyle(walkingDog).right;

        walkingDog.classList.remove("walkingAnimation");
        walkingDog.classList.add("jumpAnimation");

        console.log("dog clicked");
        setTimeout(() => {
            walkingDog.classList.remove("jumpAnimation");
            walkingDog.classList.add("walkingAnimation");

            // Set the left property to maintain the current position
            walkingDog.style.right = currentPosition;
        }, 1000);
    });
});
