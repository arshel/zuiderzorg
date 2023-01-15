
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

// Write your JavaScript code.


$(function() {
    // console.log( "ready!" );


if ($this.data('thumbnail')) {
    // Prepare thumbnail
    text =
      '<span class="media">' +
        '<span class="media-left"><img src="' + $this.data('thumbnail') + '" class="media-object" onerror="src=\'data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7\'"></span>' +
        '<span class="media-body">' + text + '</span>' +
      '</span>';
  } else if (!$this.data('content')) {
    // Prepend any icon and append any subtext to the main text
    text = icon + '<span class="text">' + text + subtext + '</span>';
  }
});
$("body").on("click", "#LoginPartial", function () {
    var url = "/?handler=" + $(this).attr("id");
    console.log(url)
    $.ajax({
        url: url,
        success: function (data) {
            $("#exampleModal .modal-dialog").html(data);
            $("#exampleModal").modal("show");
        }
    });
});



// Video pause and unpause
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


// Toggle function for the popovers.
function TogglePopovers() { $('[data-bs-toggle="popover"]').popover('toggle'); }

$(document).ready(function () {
    $('[data-bs-toggle="popover"]').popover({
        // trigger: 'manual',
        container: 'body'
    });
});


// get slider
var slider = document.getElementById("myRange");


// Update the current slider value (each time you drag the slider handle)
slider.oninput = function() {
    document.getElementsByTagName('video')[0].volume = parseFloat(this.value / 100);
};

const
    range = document.getElementById('range'),
    rangeV = document.getElementById('rangeV'),
    setValue = ()=>{
        const
            newValue = Number( (range.value - range.min) * 100 / (range.max - range.min) ),
            newPosition = 10 - (newValue * 0.2);
        rangeV.innerHTML = `<span>${range.value}</span>`;
        rangeV.style.left = `calc(${newValue}% + (${newPosition}px))`;
    };
document.addEventListener("DOMContentLoaded", setValue);
range.addEventListener('input', setValue);