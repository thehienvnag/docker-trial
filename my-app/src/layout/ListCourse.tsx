import React, { useEffect } from "react";
import { useState } from "react";

const port = process.env.REACT_APP_SPRINGBOOT_PORT;

interface CourseProps {
  item: string;
}

export const ListCourse = () => {
  const [courses, setCourses] = useState<string[]>([]);
  useEffect(() => {
    console.log("-->> componentDidMount");
    fetch(`http://localhost:${port}`)
      .then((res) => res.json())
      .then((courses) => setCourses(courses))
      .catch((err) => console.log(err));
    return () => {
      console.log("-->> componentWillUnmount");
    };
  });
  return (
    <ul>
      {courses.map((course) => (
        <Course item={course} />
      ))}
    </ul>
  );
};

const Course: React.FC<CourseProps> = ({ item }: CourseProps) => (
  <li>{item}</li>
);
