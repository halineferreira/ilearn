import React, { Component } from 'react'
import Search from '../../components/Search'
import SubjectBanner from '../../components/SubjectBanner'
import Slider from 'react-slick'
import Math from './../../images/matematica.jpg'
import Violao from './../../images/violao.jpg'
import Ingles from './../../images/ingles.jpg'
import Portugues from './../../images/portugues.jpg'
import Quimica from './../../images/quimica.jpg'
import Javascript from './../../images/javascript.jpg'
import Yoga from './../../images/yoga.jpg'
import Fisica from './../../images/fisica.jpg'
import Algoritmos from './../../images/algoritmos.jpg'

export class Home extends Component {
  static displayName = Home.name

  render() {
    const subjectSettings = {
      dots: false,
      infinite: true,
      slidesToShow: 3,
      slidesToScroll: 1,
      autoplay: true,
      autoplaySpeed: 2000,
    }

    return (
      <>
        <Search />

        <Slider {...subjectSettings}>
          <SubjectBanner text="Matemática" image={Math} />
          <SubjectBanner text="Violão" image={Violao} />
          <SubjectBanner text="Inglês" image={Ingles} />
          <SubjectBanner text="Portugês" image={Portugues} />
          <SubjectBanner text="Química" image={Quimica} />
          <SubjectBanner text="Javascript" image={Javascript} />
          <SubjectBanner text="Yoga" image={Yoga} />
          <SubjectBanner text="Física" image={Fisica} />
          <SubjectBanner text="Algoritmos" image={Algoritmos} />
        </Slider>
      </>
    )
  }
}
