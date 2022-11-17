﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var oldSliderVal = -1;
function init()
{
    var bubble = document.getElementById('bubble');
    var sliderInput = document.getElementById('myRange');

    sliderInput.addEventListener('mousemove', moveBubble);
}

var moveBubble = function(e)
{
    if(oldSliderVal !== '0' && oldSliderVal !== '100')
    {
        bubble.style.left = e.clientX-(bubble.offsetWidth/2)+'px';
    }
    var sliderVal = sliderInput.value
    bubble.innerHTML = sliderVal;
    oldSliderVal = sliderVal;
}



$('.bi').parent().click(function () 
    {
        if($(this).children(".video").get(0).paused)
        {        
            $(this).children(".video").get(0).play();   
            $(this).children(".bi").fadeOut();
    }
    else
    {       
        $(this).children(".video").get(0).pause();
        $(this).children(".bi").fadeIn();
    }
});

var slider = document.getElementById("myRange");
var output = document.getElementById("volume");
// output.innerHTML = slider.value; // Display the default slider value

// Update the current slider value (each time you drag the slider handle)
slider.oninput = function() {
    // output.innerHTML = this.value;
    
    document.getElementsByTagName('video')[0].volume = parseFloat(this.value / 100);
}

