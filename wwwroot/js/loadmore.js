let productSkip = 8;
$(document).on('click', '#loadMoreButton', function () {
        $.ajax({
            url: "/Shop/LoadMore/",
            type: "GET",
            data: {
                "skip": productSkip
            },
            success: function (response) {
                $("#myProductsList").append(response)
                productSkip += 8;
                if ($("#product-count").val() < productSkip) {
                    $("#loadMoreButton").remove()
                }

            }

        });
    }
        
    
   
})