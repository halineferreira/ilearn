import React, { Component } from 'react'
import Slider from 'react-slick'
import Image1 from './../../images/slider1.jpg'
import 'slick-carousel/slick/slick.css'
import 'slick-carousel/slick/slick-theme.css'
import './style.css'

export class SliderI extends Component {
  render() {
    var settings = {
      dots: true,
      autoplay: false,
      focusOnSelect: true,
    }
    return (
      <div id="Slider">
        <Slider {...settings}>
          <div>
            <div id="image1" className="image" />
          </div>
          <div>
            <div id="image1" className="image" />
          </div>
          <div>
            <div id="image1" className="image" />
          </div>
          <div>
            <div id="image1" className="image" />
          </div>
        </Slider>
      </div>
    )
  }
}
