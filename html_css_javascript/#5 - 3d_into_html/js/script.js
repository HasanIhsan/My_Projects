//import 3.js lib
import * as THREE from "https://cdn.skypack.dev/three@0.129.0/build/three.module.js"
//model loaded
import { GLTFLoader } from "https://cdn.skypack.dev/three@0.129.0/examples/jsm/loaders/GLTFLoader.js"

//camera controls (wern\t used)
import { OrbitControls } from "https://cdn.skypack.dev/three@0.129.0/examples/jsm/controls/OrbitControls.js"

//controls = new OrbitControls(camera, renderer.domElement);
//controls.enableDamping = true;
//controls.dampingFactor = 0.25;


//vars
const scene = new THREE.Scene();
const camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
const renderer = new THREE.WebGLRenderer({ alpha: true });
const loader = new GLTFLoader();

let object;
let objToRender = 'eye';

let mouseX = window.innerWidth / 2;
let mouseY = window.innerHeight / 2;

//load model
loader.load(
    `models/${objToRender}/scene.gltf`,
    function (gltf) {
        object = gltf.scene;
        scene.add(object);
    },
    function (xhr) {
        console.log((xhr.loaded / xhr.total * 100) + '% loaded');
    },
    function (error) {
        console.error(error);
    }
);

//add model to div
document.getElementById("container3D").appendChild(renderer.domElement);

//camera position
camera.position.z = 70;


//lights
const light = new THREE.AmbientLight();
scene.add(light);

const directionalLight = new THREE.DirectionalLight(0xffffff, 5);
directionalLight.position.set(1, 1, 1).normalize();
scene.add(directionalLight);

//resize render scene
renderer.setSize(window.innerWidth, window.innerHeight);


//animation for what i want the model to do
function animate() {
    requestAnimationFrame(animate);

    if (object && objToRender === "eye") {
        object.rotation.y = (mouseX / window.innerWidth - 0.5) * Math.PI;
        object.rotation.x = (mouseY / window.innerHeight - 0.5) * Math.PI;
    }

    renderer.render(scene, camera);
}


//if html is resized
window.addEventListener("resize", function () {
    camera.aspect = window.innerWidth / window.innerHeight;
    camera.updateProjectionMatrix();
    renderer.setSize(window.innerWidth, window.innerHeight);
});


//event listent to listen for mouse movements
document.onmousemove = (e) => {
    mouseX = e.clientX;
    mouseY = e.clientY;
}

// Start the animate
animate();
