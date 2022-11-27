import React from 'react'

import './style.css'

const SubjectBanner = ({ text, image }) => {
  return (
    <div className="subject">
      <img src={image} className="image-subject" alt={text} />
      <h5>{text}</h5>
    </div>
  )
}

export default SubjectBanner
