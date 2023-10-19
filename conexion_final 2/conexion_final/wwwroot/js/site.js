// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let particles = [];

function setup() {
    createCanvas(windowWidth, windowHeight);
    for (let i = 0; i < 100; i++) {
        particles.push(new Particle());
    }
}

function draw() {
    background(104, 178, 248);

    for (let particle of particles) {
        particle.update();
        particle.show();
    }
}

class Particle {
    constructor() {
        this.x = random(width);
        this.y = random(height);
        this.size = random(5, 10);
        this.xSpeed = random(-2, 2);
        this.ySpeed = random(-2, 2);
    }

    update() {
        this.x += this.xSpeed;
        this.y += this.ySpeed;

        if (this.x < 0 || this.x > width) {
            this.xSpeed *= -1;
        }

        if (this.y < 0 || this.y > height) {
            this.ySpeed *= -1;
        }

        // Verificar la posición del cursor
        let d = dist(mouseX, mouseY, this.x, this.y);
        if (d < 50) {
            this.xSpeed += random(-1, 1);
            this.ySpeed += random(-1, 1);
        }
    }

    show() {
        fill(255);
        noStroke();
        ellipse(this.x, this.y, this.size);
    }
}
